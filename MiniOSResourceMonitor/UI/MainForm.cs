using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniOSResourceMonitor.Models;
using MiniOSResourceMonitor.Simulation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniOSResourceMonitor.UI
{
    public partial class MainForm : Form
    {
        // ── Simulation Engine ─────────────────────────────────────────────────
        private readonly SimulationData _sim = new();

        // ── Theme Palette ─────────────────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(13, 17, 23);
        private static readonly Color C_SURFACE = Color.FromArgb(22, 27, 34);
        private static readonly Color C_SURFACE2 = Color.FromArgb(30, 37, 46);
        private static readonly Color C_BORDER = Color.FromArgb(48, 54, 61);
        private static readonly Color C_ACCENT = Color.FromArgb(88, 166, 255);
        private static readonly Color C_ACCENT2 = Color.FromArgb(63, 185, 128);
        private static readonly Color C_FG = Color.FromArgb(230, 237, 243);
        private static readonly Color C_FG_DIM = Color.FromArgb(139, 148, 158);
        private static readonly Color C_INPUT = Color.FromArgb(13, 17, 23);
        private static readonly Color C_BTN_START = Color.FromArgb(35, 134, 54);
        private static readonly Color C_BTN_STEP = Color.FromArgb(21, 83, 167);
        private static readonly Color C_BTN_RESET = Color.FromArgb(161, 29, 29);
        private static readonly Color C_BTN_ADD = Color.FromArgb(56, 96, 165);
        private static readonly Color C_BTN_DEL = Color.FromArgb(130, 40, 40);
        private static readonly Color C_BTN_EDIT = Color.FromArgb(100, 80, 20);

        // State colours
        private static readonly Color C_NEW = Color.FromArgb(100, 100, 100);
        private static readonly Color C_READY = Color.FromArgb(56, 139, 84);
        private static readonly Color C_RUNNING = Color.FromArgb(88, 166, 255);
        private static readonly Color C_WAITING = Color.FromArgb(210, 153, 34);
        private static readonly Color C_TERMINATED = Color.FromArgb(161, 29, 29);

        // ── UI Controls (declared here; initialised in Designer region) ───────
        // Config panel
        private NumericUpDown _numCpu = null!;
        private NumericUpDown _numMemory = null!;
        private NumericUpDown _numIo = null!;
        private Button _btnApply = null!;

        // Process table
        private DataGridView _grid = null!;
        private Button _btnAdd = null!;
        private Button _btnEdit = null!;
        private Button _btnDelete = null!;

        // Metrics
        private Label _lblStep = null!;
        private Label _lblCpuPct = null!;
        private Label _lblMemPct = null!;
        private Label _lblIoPct = null!;
        private Label _lblThroughput = null!;
        private Label _lblAvgWait = null!;
        private Label _lblCompleted = null!;
        private Label _lblReady = null!;
        private Label _lblRunning = null!;
        private Label _lblWaiting = null!;

        // Progress bars
        private ProgressBar _pbCpu = null!;
        private ProgressBar _pbMem = null!;
        private ProgressBar _pbIo = null!;

        // Simulation control
        private Button _btnStart = null!;
        private Button _btnStep = null!;
        private Button _btnReset = null!;

        // Log
        private RichTextBox _log = null!;

        public MainForm()
        {
            InitializeComponent();
            WireEvents();
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            Log("🖥  Mini OS Resource Monitor ready. Configure system and add processes.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  EVENT WIRING
        // ─────────────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            _btnApply.Click += BtnApply_Click;
            _btnAdd.Click += BtnAdd_Click;
            _btnEdit.Click += BtnEdit_Click;
            _btnDelete.Click += BtnDelete_Click;
            _btnStart.Click += BtnStart_Click;
            _btnStep.Click += BtnStep_Click;
            _btnReset.Click += BtnReset_Click;
            _grid.CellFormatting += Grid_CellFormatting;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  BUTTON HANDLERS
        // ─────────────────────────────────────────────────────────────────────
        private void BtnApply_Click(object? sender, EventArgs e)
        {
            if (_sim.IsConfigLocked)
            {
                Log("⚠  Configuration is locked while simulation is running. Reset first.");
                return;
            }

            var cfg = new SystemConfig
            {
                TotalCpuUnits = (int)_numCpu.Value,
                TotalMemoryMB = (int)_numMemory.Value,
                TotalIoUnits = (int)_numIo.Value
            };

            if (_sim.ApplyConfig(cfg))
                Log($"✅  Config applied — CPU: {cfg.TotalCpuUnits} units | " +
                    $"RAM: {cfg.TotalMemoryMB} MB | I/O: {cfg.TotalIoUnits} units");
            else
                Log("❌  Invalid configuration values.");
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var cfg = _sim.GetConfig();
            using var form = new AddProcessForm(
                cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits);

            if (form.ShowDialog(this) == DialogResult.OK && form.Result != null)
            {
                int id = _sim.AddProcess(form.Result);
                Log($"➕  Added [{form.Result.Name}] — CPU:{form.Result.CpuRequirement} " +
                    $"MEM:{form.Result.MemoryRequirementMB}MB " +
                    $"I/O:{form.Result.IoRequirement} Burst:{form.Result.RemainingBurstTime}");
                RefreshGrid();
                UpdateMetricsDisplay(_sim.GetMetrics());
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedProcessId();
            if (id < 0) { Log("⚠  Select a process to edit."); return; }

            var proc = _sim.GetProcessById(id);
            if (proc == null) return;

            if (proc.State == ProcessState.Running ||
                proc.State == ProcessState.Waiting ||
                proc.State == ProcessState.Terminated)
            {
                Log($"⚠  Cannot edit [{proc.Name}] — state is {proc.State}.");
                return;
            }

            var cfg = _sim.GetConfig();
            using var form = new AddProcessForm(
                cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits, proc);

            if (form.ShowDialog(this) == DialogResult.OK && form.Result != null)
            {
                _sim.UpdateProcess(form.Result);
                Log($"✏️  Updated [{form.Result.Name}]");
                RefreshGrid();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedProcessId();
            if (id < 0) { Log("⚠  Select a process to delete."); return; }

            var proc = _sim.GetProcessById(id);
            if (proc == null) return;

            if (!_sim.RemoveProcess(id))
            {
                Log($"⚠  Cannot delete [{proc.Name}] while it is Running.");
                return;
            }

            Log($"🗑  Removed [{proc.Name}]");
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            if (_sim.IsStarted) { Log("⚠  Simulation already started."); return; }

            if (_sim.GetAllProcesses().Count == 0)
            {
                Log("⚠  Add at least one process before starting.");
                return;
            }

            _sim.Start();
            _btnApply.Enabled = false;
            _btnStart.Enabled = false;
            Log("▶  Simulation started. Use [Next Step] to advance.");
        }

        private void BtnStep_Click(object? sender, EventArgs e)
        {
            if (!_sim.IsStarted)
            {
                Log("⚠  Click [Start Simulation] first.");
                return;
            }

            var metrics = _sim.NextStep();
            RefreshGrid();
            UpdateMetricsDisplay(metrics);
            Log($"⏭  Step {_sim.CurrentStep} — CPU:{metrics.CpuUtilizationPercent:F1}%  " +
                $"MEM:{metrics.UsedMemoryMB}MB  " +
                $"Completed:{metrics.CompletedProcesses}  " +
                $"Throughput:{metrics.Throughput:F2}");
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _sim.Reset();
            _numCpu.Value = _sim.GetConfig().TotalCpuUnits;
            _numMemory.Value = _sim.GetConfig().TotalMemoryMB;
            _numIo.Value = _sim.GetConfig().TotalIoUnits;
            _btnApply.Enabled = true;
            _btnStart.Enabled = true;
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            Log("🔄  Simulation reset. All processes cleared.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  GRID
        // ─────────────────────────────────────────────────────────────────────
        private void RefreshGrid()
        {
            _grid.Rows.Clear();
            foreach (var p in _sim.GetAllProcesses())
            {
                _grid.Rows.Add(
                    p.ProcessId,
                    p.Name,
                    p.CpuRequirement,
                    p.MemoryRequirementMB,
                    p.IoRequirement,
                    p.RemainingBurstTime > 0 ? p.RemainingBurstTime.ToString() : "—",
                    p.TotalWaitingSteps,
                    p.State.ToString()
                );
            }
        }

        private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var stateCell = _grid.Rows[e.RowIndex].Cells[7];
            if (stateCell.Value == null) return;

            Color stateColor = stateCell.Value.ToString() switch
            {
                "New" => C_NEW,
                "Ready" => C_READY,
                "Running" => C_RUNNING,
                "Waiting" => C_WAITING,
                "Terminated" => C_TERMINATED,
                _ => C_FG_DIM
            };

            // Colour entire row subtly; colour state cell strongly
            _grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = C_FG;
            stateCell.Style.ForeColor = stateColor;
            stateCell.Style.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            stateCell.Style.BackColor = Color.FromArgb(30, stateColor.R, stateColor.G, stateColor.B);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  METRICS DISPLAY
        // ─────────────────────────────────────────────────────────────────────
        private void UpdateMetricsDisplay(PerformanceMetrics m)
        {
            _lblStep.Text = $"Step: {m.SimulationStep}";
            _lblCpuPct.Text = $"{m.CpuUtilizationPercent:F1}%";
            _lblMemPct.Text = $"{m.MemoryUtilizationPercent:F1}%";
            _lblIoPct.Text = m.TotalIoUnits > 0
                                     ? $"{(m.UsedIoUnits / (double)m.TotalIoUnits * 100):F1}%"
                                     : "0.0%";
            _lblThroughput.Text = $"{m.Throughput:F3} proc/step";
            _lblAvgWait.Text = $"{m.AverageWaitingTime:F2} steps";
            _lblCompleted.Text = m.CompletedProcesses.ToString();
            _lblReady.Text = m.ReadyQueueCount.ToString();
            _lblRunning.Text = m.RunningCount.ToString();
            _lblWaiting.Text = m.WaitingCount.ToString();

            SetBar(_pbCpu, (int)Math.Round(m.CpuUtilizationPercent));
            SetBar(_pbMem, (int)Math.Round(m.MemoryUtilizationPercent));
            double ioPct = m.TotalIoUnits > 0
                               ? m.UsedIoUnits / (double)m.TotalIoUnits * 100
                               : 0;
            SetBar(_pbIo, (int)Math.Round(ioPct));
        }

        private static void SetBar(ProgressBar pb, int value)
            => pb.Value = Math.Max(0, Math.Min(100, value));

        // ─────────────────────────────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────────────────────────────
        private int GetSelectedProcessId()
        {
            if (_grid.SelectedRows.Count == 0) return -1;
            var cell = _grid.SelectedRows[0].Cells[0].Value;
            return cell is int id ? id : -1;
        }

        private void Log(string message)
        {
            string ts = DateTime.Now.ToString("HH:mm:ss");
            _log.SelectionStart = _log.TextLength;
            _log.SelectionLength = 0;
            _log.SelectionColor = C_FG_DIM;
            _log.AppendText($"[{ts}]  ");
            _log.SelectionColor = C_FG;
            _log.AppendText(message + "\n");
            _log.ScrollToCaret();
        }
    }
}