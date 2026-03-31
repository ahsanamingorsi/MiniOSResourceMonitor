using MiniOSResourceMonitor.Models;
using MiniOSResourceMonitor.Simulation;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniOSResourceMonitor.UI
{
    public partial class MainForm : Form
    {
        private readonly SimulationData _sim = new SimulationData();

        // ── Colours ───────────────────────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(13, 17, 23);
        private static readonly Color C_SURFACE = Color.FromArgb(22, 27, 34);
        private static readonly Color C_SURFACE2 = Color.FromArgb(30, 37, 46);
        private static readonly Color C_BORDER = Color.FromArgb(48, 54, 61);
        private static readonly Color C_ACCENT = Color.FromArgb(88, 166, 255);
        private static readonly Color C_ACCENT2 = Color.FromArgb(63, 185, 128);
        private static readonly Color C_FG = Color.FromArgb(230, 237, 243);
        private static readonly Color C_FG_DIM = Color.FromArgb(139, 148, 158);
        private static readonly Color C_BTN_START = Color.FromArgb(35, 134, 54);
        private static readonly Color C_BTN_STEP = Color.FromArgb(21, 83, 167);
        private static readonly Color C_BTN_RESET = Color.FromArgb(161, 29, 29);
        private static readonly Color C_BTN_ADD = Color.FromArgb(56, 96, 165);
        private static readonly Color C_BTN_DEL = Color.FromArgb(130, 40, 40);
        private static readonly Color C_BTN_EDIT = Color.FromArgb(100, 80, 20);
        private static readonly Color C_BTN_APPLY = Color.FromArgb(56, 96, 165);
        private static readonly Color C_NEW = Color.FromArgb(100, 100, 100);
        private static readonly Color C_READY = Color.FromArgb(56, 139, 84);
        private static readonly Color C_RUNNING = Color.FromArgb(88, 166, 255);
        private static readonly Color C_WAITING = Color.FromArgb(210, 153, 34);
        private static readonly Color C_TERMINATED = Color.FromArgb(161, 29, 29);

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            BuildGridColumns();
            WireEvents();
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            Log("Mini OS Resource Monitor ready. Configure system and add processes.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  THEME
        // ─────────────────────────────────────────────────────────────────────
        private void ApplyTheme()
        {
            BackColor = C_BG;
            ForeColor = C_FG;
            Font = new Font("Segoe UI", 9f);

            // Title bar
            lblAppTitle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblAppTitle.ForeColor = C_ACCENT;
            lblAppTitle.Text = "  Mini OS Resource Monitor";
            lblSubtitle.ForeColor = C_FG_DIM;
            lblStepDisplay.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblStepDisplay.ForeColor = C_ACCENT2;

            // Legend
            pnlLegend.BackColor = C_SURFACE;
            lblLegNew.ForeColor = C_NEW;
            lblLegNew.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblLegReady.ForeColor = C_READY;
            lblLegReady.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblLegRunning.ForeColor = C_RUNNING;
            lblLegRunning.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblLegWaiting.ForeColor = C_WAITING;
            lblLegWaiting.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblLegTerm.ForeColor = C_TERMINATED;
            lblLegTerm.Font = new Font("Segoe UI", 8f, FontStyle.Bold);

            // Config panel headers
            StylePanelHeader(lblConfigHdr, "  SYSTEM CONFIGURATION");
            StylePanelHeader(lblCtrlHdr, "  SIMULATION CONTROLS");
            StylePanelHeader(lblResHdr, "  RESOURCE UTILISATION");
            StylePanelHeader(lblPerfHdr, "  PERFORMANCE METRICS");
            StylePanelHeader(lblProcHdr, "  PROCESS TABLE");
            StylePanelHeader(lblLogHdr, "  ACTIVITY LOG");

            // Dim labels
            Color dim = C_FG_DIM;
            foreach (var lbl in new Label[]
                { lblCpuLbl, lblMemLbl, lblIoLbl,
                  lblCpuTag, lblMemTag, lblIoTag,
                  lblReadyTag, lblRunningTag, lblWaitingTag,
                  lblThruTag, lblWaitTag, lblCompTag })
            {
                lbl.ForeColor = dim;
                lbl.Font = new Font("Segoe UI", 8f);
            }

            // Value labels
            foreach (var lbl in new Label[]
                { lblCpuPct, lblMemPct, lblIoPct,
                  lblThroughput, lblAvgWait, lblCompleted })
            {
                lbl.ForeColor = C_FG;
                lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }

            // Queue count labels
            lblReady.ForeColor = C_READY;
            lblReady.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblRunning.ForeColor = C_RUNNING;
            lblRunning.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblWaiting.ForeColor = C_WAITING;
            lblWaiting.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

            // Numeric inputs
            foreach (var n in new NumericUpDown[] { numCpu, numMemory, numIo })
            {
                n.BackColor = C_BG;
                n.ForeColor = C_FG;
                n.Font = new Font("Segoe UI", 9f);
            }

            // Buttons
            StyleButton(btnApply, "  Apply Config", C_BTN_APPLY);
            StyleButton(btnStart, "  Start Simulation", C_BTN_START);
            StyleButton(btnStep, "  Next Step", C_BTN_STEP);
            StyleButton(btnReset, "  Reset", C_BTN_RESET);
            StyleButton(btnAdd, "  Add", C_BTN_ADD);
            StyleButton(btnEdit, "  Edit", C_BTN_EDIT);
            StyleButton(btnDelete, "  Delete", C_BTN_DEL);

            // Grid
            grid.BackgroundColor = C_SURFACE2;
            grid.GridColor = C_BORDER;
            grid.Font = new Font("Consolas", 9f);
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE2,
                ForeColor = C_FG,
                SelectionBackColor = Color.FromArgb(40, 88, 166, 255),
                SelectionForeColor = C_FG,
                Padding = new Padding(4, 0, 4, 0)
            };
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE,
                ForeColor = C_ACCENT,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Padding = new Padding(4)
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(26, 32, 40)
            };
            grid.EnableHeadersVisualStyles = false;
            grid.RowTemplate.Height = 28;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Log
            rtbLog.BackColor = C_SURFACE;
            rtbLog.ForeColor = C_FG;
            rtbLog.Font = new Font("Consolas", 8.5f);
        }

        private void StylePanelHeader(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.ForeColor = C_ACCENT;
        }

        private void StyleButton(Button btn, string text, Color back)
        {
            btn.Text = text;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  GRID COLUMNS
        // ─────────────────────────────────────────────────────────────────────
        private void BuildGridColumns()
        {
            grid.Columns.Clear();
            string[] names = { "PID", "Name", "CPU", "Memory (MB)", "I/O", "Burst Left", "Wait Steps", "State" };
            int[] widths = { 40, 140, 50, 90, 40, 70, 70, 80 };

            for (int i = 0; i < names.Length; i++)
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = names[i],
                    ReadOnly = true,
                    FillWeight = widths[i],
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            grid.CellFormatting += Grid_CellFormatting;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  EVENT WIRING
        // ─────────────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            // All button Click handlers are wired in Designer.cs via +=
            // Nothing extra needed here unless adding keyboard shortcuts
        }

        // ─────────────────────────────────────────────────────────────────────
        //  BUTTON HANDLERS
        // ─────────────────────────────────────────────────────────────────────
        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (_sim.IsConfigLocked)
            {
                Log("Configuration is locked while simulation is running. Reset first.");
                return;
            }

            var cfg = new SystemConfig
            {
                TotalCpuUnits = (int)numCpu.Value,
                TotalMemoryMB = (int)numMemory.Value,
                TotalIoUnits = (int)numIo.Value
            };

            if (_sim.ApplyConfig(cfg))
                Log("Config applied — CPU: " + cfg.TotalCpuUnits +
                    " units | RAM: " + cfg.TotalMemoryMB +
                    " MB | I/O: " + cfg.TotalIoUnits + " units");
            else
                Log("Invalid configuration values.");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var cfg = _sim.GetConfig();
            using (var form = new AddProcessForm(
                       cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Result != null)
                {
                    _sim.AddProcess(form.Result);
                    Log("Added [" + form.Result.Name + "]  CPU:" +
                        form.Result.CpuRequirement + "  MEM:" +
                        form.Result.MemoryRequirementMB + "MB  I/O:" +
                        form.Result.IoRequirement + "  Burst:" +
                        form.Result.RemainingBurstTime);
                    RefreshGrid();
                    UpdateMetricsDisplay(_sim.GetMetrics());
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProcessId();
            if (id < 0) { Log("Select a process to edit."); return; }

            var proc = _sim.GetProcessById(id);
            if (proc == null) return;

            if (proc.State == ProcessState.Running ||
                proc.State == ProcessState.Waiting ||
                proc.State == ProcessState.Terminated)
            {
                Log("Cannot edit [" + proc.Name + "] — state is " + proc.State + ".");
                return;
            }

            var cfg = _sim.GetConfig();
            using (var form = new AddProcessForm(
                       cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits, proc))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Result != null)
                {
                    _sim.UpdateProcess(form.Result);
                    Log("Updated [" + form.Result.Name + "]");
                    RefreshGrid();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProcessId();
            if (id < 0) { Log("Select a process to delete."); return; }

            var proc = _sim.GetProcessById(id);
            if (proc == null) return;

            if (!_sim.RemoveProcess(id))
            {
                Log("Cannot delete [" + proc.Name + "] while it is Running.");
                return;
            }

            Log("Removed [" + proc.Name + "]");
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (_sim.IsStarted) { Log("Simulation already started."); return; }

            if (_sim.GetAllProcesses().Count == 0)
            {
                Log("Add at least one process before starting.");
                return;
            }

            _sim.Start();
            btnApply.Enabled = false;
            btnStart.Enabled = false;
            Log("Simulation started. Use [Next Step] to advance.");
        }

        private void BtnStep_Click(object sender, EventArgs e)
        {
            if (!_sim.IsStarted) { Log("Click [Start Simulation] first."); return; }

            var metrics = _sim.NextStep();
            RefreshGrid();
            UpdateMetricsDisplay(metrics);
            Log("Step " + _sim.CurrentStep +
                " — CPU:" + metrics.CpuUtilizationPercent.ToString("F1") + "%" +
                "  MEM:" + metrics.UsedMemoryMB + "MB" +
                "  Done:" + metrics.CompletedProcesses +
                "  Throughput:" + metrics.Throughput.ToString("F3"));
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            _sim.Reset();
            numCpu.Value = _sim.GetConfig().TotalCpuUnits;
            numMemory.Value = _sim.GetConfig().TotalMemoryMB;
            numIo.Value = _sim.GetConfig().TotalIoUnits;
            btnApply.Enabled = true;
            btnStart.Enabled = true;
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            Log("Simulation reset. All processes cleared.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  GRID
        // ─────────────────────────────────────────────────────────────────────
        private void RefreshGrid()
        {
            grid.Rows.Clear();
            foreach (var p in _sim.GetAllProcesses())
            {
                string burst = p.RemainingBurstTime > 0
                               ? p.RemainingBurstTime.ToString()
                               : "Done";
                grid.Rows.Add(
                    p.ProcessId,
                    p.Name,
                    p.CpuRequirement,
                    p.MemoryRequirementMB,
                    p.IoRequirement,
                    burst,
                    p.TotalWaitingSteps,
                    p.State.ToString()
                );
            }
        }

        private void Grid_CellFormatting(object sender,
                                         DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var stateCell = grid.Rows[e.RowIndex].Cells[7];
            if (stateCell.Value == null) return;

            string state = stateCell.Value.ToString();
            Color stateColor;

            if (state == "New") stateColor = C_NEW;
            else if (state == "Ready") stateColor = C_READY;
            else if (state == "Running") stateColor = C_RUNNING;
            else if (state == "Waiting") stateColor = C_WAITING;
            else if (state == "Terminated") stateColor = C_TERMINATED;
            else stateColor = C_FG_DIM;

            stateCell.Style.ForeColor = stateColor;
            stateCell.Style.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            stateCell.Style.BackColor = Color.FromArgb(30,
                                             stateColor.R,
                                             stateColor.G,
                                             stateColor.B);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  METRICS
        // ─────────────────────────────────────────────────────────────────────
        private void UpdateMetricsDisplay(PerformanceMetrics m)
        {
            lblStepDisplay.Text = "Step: " + m.SimulationStep;
            lblCpuPct.Text = m.CpuUtilizationPercent.ToString("F1") + "%";
            lblMemPct.Text = m.MemoryUtilizationPercent.ToString("F1") + "%";

            double ioPct = m.TotalIoUnits > 0
                           ? m.UsedIoUnits / (double)m.TotalIoUnits * 100
                           : 0;
            lblIoPct.Text = ioPct.ToString("F1") + "%";
            lblThroughput.Text = m.Throughput.ToString("F3") + " proc/step";
            lblAvgWait.Text = m.AverageWaitingTime.ToString("F2") + " steps";
            lblCompleted.Text = m.CompletedProcesses.ToString();
            lblReady.Text = m.ReadyQueueCount.ToString();
            lblRunning.Text = m.RunningCount.ToString();
            lblWaiting.Text = m.WaitingCount.ToString();

            SetBar(pbCpu, (int)Math.Round(m.CpuUtilizationPercent));
            SetBar(pbMem, (int)Math.Round(m.MemoryUtilizationPercent));
            SetBar(pbIo, (int)Math.Round(ioPct));
        }

        private static void SetBar(ProgressBar pb, int value)
        {
            pb.Value = value < 0 ? 0 : value > 100 ? 100 : value;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────────────────────────────
        private int GetSelectedProcessId()
        {
            if (grid.SelectedRows.Count == 0) return -1;
            object cell = grid.SelectedRows[0].Cells[0].Value;
            if (cell is int id) return id;
            return -1;
        }

        private void Log(string message)
        {
            string ts = DateTime.Now.ToString("HH:mm:ss");
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = C_FG_DIM;
            rtbLog.AppendText("[" + ts + "]  ");
            rtbLog.SelectionColor = C_FG;
            rtbLog.AppendText(message + "\n");
            rtbLog.ScrollToCaret();
        }
    }
}