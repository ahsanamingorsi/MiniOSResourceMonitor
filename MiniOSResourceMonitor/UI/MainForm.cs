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
        private readonly SimulationData _sim = new SimulationData();

        // ── Graph history ──────────────────────────────────────────────────────
        private readonly List<int> _cpuHistory = new List<int>();
        private readonly List<int> _memHistory = new List<int>();
        private readonly List<int> _ioHistory = new List<int>();
        private const int MAX_HISTORY = 30;

        // ── Palette ───────────────────────────────────────────────────────────
        private static readonly Color C_BG = Color.FromArgb(11, 14, 20);
        private static readonly Color C_SURFACE = Color.FromArgb(20, 25, 36);
        private static readonly Color C_SURFACE2 = Color.FromArgb(27, 33, 46);
        private static readonly Color C_BORDER = Color.FromArgb(44, 54, 72);
        private static readonly Color C_ACCENT = Color.FromArgb(80, 160, 255);
        private static readonly Color C_ACCENT2 = Color.FromArgb(48, 200, 130);
        private static readonly Color C_FG = Color.FromArgb(218, 228, 244);
        private static readonly Color C_FG_DIM = Color.FromArgb(108, 122, 148);
        private static readonly Color C_NEW = Color.FromArgb(108, 115, 130);
        private static readonly Color C_READY = Color.FromArgb(48, 200, 130);
        private static readonly Color C_RUNNING = Color.FromArgb(80, 160, 255);
        private static readonly Color C_WAITING = Color.FromArgb(240, 165, 50);
        private static readonly Color C_TERMINATED = Color.FromArgb(215, 68, 68);
        private static readonly Color C_CPU_LINE = Color.FromArgb(80, 160, 255);
        private static readonly Color C_MEM_LINE = Color.FromArgb(48, 200, 130);
        private static readonly Color C_IO_LINE = Color.FromArgb(240, 165, 50);

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            PositionAnchoredButtons();
            BuildGridColumns();
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            DrawGraph();
            Log("Mini OS Resource Monitor ready. Configure system then add processes.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  POSITION ANCHORED BUTTONS (right-aligned in pnlProcBar)
        //  Called once on load and again on resize
        // ─────────────────────────────────────────────────────────────────────
        private void PositionAnchoredButtons()
        {
            int right = pnlProcBar.ClientSize.Width - 10;
            int top = 10;
            int bw = 90;
            int bh = 32;
            int gap = 6;

            btnDelete.SetBounds(right - bw, top, bw, bh);
            btnEdit.SetBounds(right - bw * 2 - gap, top, bw, bh);
            btnAdd.SetBounds(right - bw * 3 - gap * 2, top, bw, bh);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionAnchoredButtons();

            // Keep step label right-aligned in title bar
            lblStepDisplay.Left = pnlTitle.ClientSize.Width
                                  - lblStepDisplay.Width - 16;

            // Redraw graph at new size
            if (picGraph != null && picGraph.Width > 10)
                DrawGraph();
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
            pnlTitle.BackColor = C_SURFACE;
            pnlTitle.Paint += BorderPaint;
            lblAppTitle.Font = new Font("Segoe UI Semibold", 13f);
            lblAppTitle.ForeColor = C_ACCENT;
            lblAppTitle.Text = "  ⚙  Mini OS Resource Monitor";
            lblSubtitle.ForeColor = C_FG_DIM;
            lblSubtitle.Font = new Font("Segoe UI", 8.5f);
            lblStepDisplay.Font = new Font("Segoe UI Semibold", 11f);
            lblStepDisplay.ForeColor = C_ACCENT2;
            // Position step label on right
            lblStepDisplay.Top = 14;
            lblStepDisplay.Left = 1100;

            // Legend bar
            pnlLegend.BackColor = C_SURFACE;
            pnlLegend.Paint += BorderPaint;
            SetLegLabel(lblLegNew, "●  New", C_NEW);
            SetLegLabel(lblLegReady, "●  Ready", C_READY);
            SetLegLabel(lblLegRunning, "●  Running", C_RUNNING);
            SetLegLabel(lblLegWaiting, "●  Waiting", C_WAITING);
            SetLegLabel(lblLegTerm, "●  Terminated", C_TERMINATED);

            // Left scroll area
            scrlLeft.BackColor = C_BG;

            // Cards
            Card(pnlConfig, lblConfigHdr, "⚙  SYSTEM CONFIGURATION");
            Dim(lblCpuLbl, "CPU Units (total)");
            Dim(lblMemLbl, "Memory (MB)");
            Dim(lblIoLbl, "I/O Units");
            Num(numCpu); Num(numMemory); Num(numIo);
            Btn(btnApply, "  Apply Config", Color.FromArgb(38, 76, 140));

            Card(pnlCtrl, lblCtrlHdr, "▶  SIMULATION CONTROLS");
            Btn(btnStart, "  ▶  Start Simulation", Color.FromArgb(28, 115, 58));
            Btn(btnStep, "  ⏭  Next Step", Color.FromArgb(24, 76, 158));
            Btn(btnReset, "  ⟳  Reset", Color.FromArgb(135, 33, 33));

            Card(pnlRes, lblResHdr, "📊  RESOURCE UTILISATION");
            Dim(lblCpuTag, "CPU");
            Dim(lblMemTag, "Memory");
            Dim(lblIoTag, "I/O");
            Dim(lblReadyTag, "Ready");
            Dim(lblRunningTag, "Running");
            Dim(lblWaitingTag, "Waiting");
            Val(lblCpuPct, "0.0%", C_CPU_LINE);
            Val(lblMemPct, "0.0%", C_MEM_LINE);
            Val(lblIoPct, "0.0%", C_IO_LINE);
            Val(lblReadyVal, "0", C_READY);
            Val(lblRunningVal, "0", C_RUNNING);
            Val(lblWaitingVal, "0", C_WAITING);
            pbCpu.ForeColor = C_CPU_LINE;
            pbMem.ForeColor = C_MEM_LINE;
            pbIo.ForeColor = C_IO_LINE;

            Card(pnlPerf, lblPerfHdr, "📈  PERFORMANCE METRICS");
            Dim(lblThruTag, "Throughput:");
            Dim(lblWaitTag, "Avg Wait Time:");
            Dim(lblCompTag, "Completed:");
            Val(lblThroughput, "0.000 proc/step", C_FG);
            Val(lblAvgWait, "0.00 steps", C_FG);
            Val(lblCompleted, "0", C_ACCENT2);

            Card(pnlGraph, lblGraphHdr, "📉  RESOURCE HISTORY");
            picGraph.BackColor = C_SURFACE2;

            // Right column
            pnlRight.BackColor = C_BG;
            pnlProcBar.BackColor = C_SURFACE;
            pnlProcBar.Paint += BorderPaint;
            lblProcHdr.Font = new Font("Segoe UI Semibold", 10f);
            lblProcHdr.ForeColor = C_ACCENT;
            lblProcHdr.Text = "  🗂  PROCESS TABLE";
            Btn(btnAdd, "  ➕  Add", Color.FromArgb(36, 76, 148));
            Btn(btnEdit, "  ✏  Edit", Color.FromArgb(88, 68, 18));
            Btn(btnDelete, "  🗑  Delete", Color.FromArgb(118, 28, 28));

            // Grid
            grid.BackgroundColor = C_SURFACE2;
            grid.GridColor = C_BORDER;
            grid.Font = new Font("Consolas", 9f);
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE2,
                ForeColor = C_FG,
                SelectionBackColor = Color.FromArgb(48, 80, 160, 255),
                SelectionForeColor = C_FG,
                Padding = new Padding(8, 0, 8, 0)
            };
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE,
                ForeColor = C_ACCENT,
                Font = new Font("Segoe UI Semibold", 8.5f),
                Padding = new Padding(8, 4, 8, 4)
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(23, 29, 41)
            };
            grid.EnableHeadersVisualStyles = false;
            grid.RowTemplate.Height = 30;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Log
            pnlLog.BackColor = C_SURFACE;
            pnlLog.Paint += BorderPaint;
            lblLogHdr.Font = new Font("Segoe UI Semibold", 9.5f);
            lblLogHdr.ForeColor = C_ACCENT;
            lblLogHdr.Text = "  📋  ACTIVITY LOG";
            rtbLog.BackColor = C_SURFACE;
            rtbLog.ForeColor = C_FG;
            rtbLog.Font = new Font("Consolas", 8.5f);
        }

        // ── Theme shorthand helpers ───────────────────────────────────────────
        private void Card(Panel p, Label h, string title)
        {
            p.BackColor = C_SURFACE;
            p.Paint += BorderPaint;
            h.Font = new Font("Segoe UI Semibold", 9f);
            h.ForeColor = C_ACCENT;
            h.Text = title;
        }
        private void Dim(Label l, string t)
        {
            l.Text = t; l.ForeColor = C_FG_DIM;
            l.Font = new Font("Segoe UI", 8.5f);
        }
        private void Val(Label l, string t, Color c)
        {
            l.Text = t; l.ForeColor = c;
            l.Font = new Font("Segoe UI Semibold", 9.5f);
        }
        private void Num(NumericUpDown n)
        {
            n.BackColor = C_SURFACE2; n.ForeColor = C_FG;
            n.Font = new Font("Segoe UI", 9f);
        }
        private void Btn(Button b, string text, Color back)
        {
            b.Text = text; b.BackColor = back;
            b.ForeColor = Color.White; b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Lighten(back, 30);
            b.Font = new Font("Segoe UI Semibold", 9f);
            b.Cursor = Cursors.Hand;
        }
        private void SetLegLabel(Label l, string t, Color c)
        {
            l.Text = t; l.ForeColor = c;
            l.Font = new Font("Segoe UI Semibold", 8.5f);
        }
        private static void BorderPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            using var pen = new Pen(Color.FromArgb(44, 54, 72), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }
        private static Color Lighten(Color c, int amt)
            => Color.FromArgb(
                Math.Min(c.R + amt, 255),
                Math.Min(c.G + amt, 255),
                Math.Min(c.B + amt, 255));

        // ─────────────────────────────────────────────────────────────────────
        //  GRID COLUMNS
        // ─────────────────────────────────────────────────────────────────────
        private void BuildGridColumns()
        {
            grid.Columns.Clear();
            string[] names = { "PID", "Name", "CPU Req", "Mem (MB)", "I/O", "Burst Left", "Wait Steps", "State" };
            int[] widths = { 36, 160, 64, 80, 44, 80, 80, 88 };
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
        //  BUTTON HANDLERS
        // ─────────────────────────────────────────────────────────────────────
        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (_sim.IsConfigLocked) { Log("Config locked. Reset first."); return; }
            var cfg = new SystemConfig
            {
                TotalCpuUnits = (int)numCpu.Value,
                TotalMemoryMB = (int)numMemory.Value,
                TotalIoUnits = (int)numIo.Value
            };
            if (_sim.ApplyConfig(cfg))
                Log("Config applied — CPU:" + cfg.TotalCpuUnits +
                    "  RAM:" + cfg.TotalMemoryMB + "MB" +
                    "  I/O:" + cfg.TotalIoUnits);
            else
                Log("Invalid config values.");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var cfg = _sim.GetConfig();
            using (var f = new AddProcessForm(cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits))
            {
                if (f.ShowDialog(this) == DialogResult.OK && f.Result != null)
                {
                    _sim.AddProcess(f.Result);
                    Log("Added [" + f.Result.Name + "]");
                    RefreshGrid();
                    UpdateMetricsDisplay(_sim.GetMetrics());
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int id = SelectedId();
            if (id < 0) { Log("Select a process to edit."); return; }
            var proc = _sim.GetProcessById(id);
            if (proc == null) return;
            if (proc.State == ProcessState.Running ||
                proc.State == ProcessState.Waiting ||
                proc.State == ProcessState.Terminated)
            { Log("Cannot edit — state: " + proc.State); return; }
            var cfg = _sim.GetConfig();
            using (var f = new AddProcessForm(cfg.TotalCpuUnits, cfg.TotalMemoryMB, cfg.TotalIoUnits, proc))
            {
                if (f.ShowDialog(this) == DialogResult.OK && f.Result != null)
                {
                    _sim.UpdateProcess(f.Result);
                    Log("Updated [" + f.Result.Name + "]");
                    RefreshGrid();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = SelectedId();
            if (id < 0) { Log("Select a process to delete."); return; }
            var proc = _sim.GetProcessById(id);
            if (proc == null) return;
            if (!_sim.RemoveProcess(id)) { Log("Cannot delete Running process."); return; }
            Log("Deleted [" + proc.Name + "]");
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (_sim.IsStarted) { Log("Already started."); return; }
            if (_sim.GetAllProcesses().Count == 0) { Log("Add processes first."); return; }
            _sim.Start();
            btnApply.Enabled = false;
            btnStart.Enabled = false;
            Log("Simulation started — click Next Step.");
        }

        private void BtnStep_Click(object sender, EventArgs e)
        {
            if (!_sim.IsStarted) { Log("Start simulation first."); return; }
            var m = _sim.NextStep();
            RefreshGrid();
            UpdateMetricsDisplay(m);
            RecordHistory(m);
            DrawGraph();
            Log("Step " + _sim.CurrentStep +
                "  CPU:" + m.CpuUtilizationPercent.ToString("F1") + "%" +
                "  MEM:" + m.UsedMemoryMB + "MB" +
                "  Done:" + m.CompletedProcesses);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            _sim.Reset();
            _cpuHistory.Clear(); _memHistory.Clear(); _ioHistory.Clear();
            numCpu.Value = _sim.GetConfig().TotalCpuUnits;
            numMemory.Value = _sim.GetConfig().TotalMemoryMB;
            numIo.Value = _sim.GetConfig().TotalIoUnits;
            btnApply.Enabled = true;
            btnStart.Enabled = true;
            RefreshGrid();
            UpdateMetricsDisplay(_sim.GetMetrics());
            DrawGraph();
            Log("Reset. All processes cleared.");
        }

        // ─────────────────────────────────────────────────────────────────────
        //  GRID  — overlap bug fix: clear + suspend + invalidate
        // ─────────────────────────────────────────────────────────────────────
        private void RefreshGrid()
        {
            grid.SuspendLayout();
            grid.Rows.Clear();
            foreach (var p in _sim.GetAllProcesses())
            {
                grid.Rows.Add(
                    p.ProcessId,
                    p.Name,
                    p.CpuRequirement,
                    p.MemoryRequirementMB,
                    p.IoRequirement,
                    p.State == ProcessState.Terminated ? "—" : p.RemainingBurstTime.ToString(),
                    p.TotalWaitingSteps,
                    p.State.ToString()
                );
            }
            grid.ResumeLayout();
            grid.Invalidate();
        }

        private void Grid_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 7) return;
            var cell = grid.Rows[e.RowIndex].Cells[7];
            if (cell.Value == null) return;
            string s = cell.Value.ToString();
            Color col = s == "New" ? C_NEW
                      : s == "Ready" ? C_READY
                      : s == "Running" ? C_RUNNING
                      : s == "Waiting" ? C_WAITING
                      : s == "Terminated" ? C_TERMINATED
                      : C_FG_DIM;
            e.CellStyle.ForeColor = col;
            e.CellStyle.Font = new Font("Segoe UI Semibold", 8.5f);
            e.CellStyle.BackColor = Color.FromArgb(30, col.R, col.G, col.B);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  METRICS
        // ─────────────────────────────────────────────────────────────────────
        private void UpdateMetricsDisplay(PerformanceMetrics m)
        {
            lblStepDisplay.Text = "Step: " + m.SimulationStep;
            double ioPct = m.TotalIoUnits > 0
                           ? m.UsedIoUnits / (double)m.TotalIoUnits * 100.0 : 0;
            lblCpuPct.Text = m.CpuUtilizationPercent.ToString("F1") + "%";
            lblMemPct.Text = m.MemoryUtilizationPercent.ToString("F1") + "%";
            lblIoPct.Text = ioPct.ToString("F1") + "%";
            lblThroughput.Text = m.Throughput.ToString("F3") + " proc/step";
            lblAvgWait.Text = m.AverageWaitingTime.ToString("F2") + " steps";
            lblCompleted.Text = m.CompletedProcesses.ToString();
            lblReadyVal.Text = m.ReadyQueueCount.ToString();
            lblRunningVal.Text = m.RunningCount.ToString();
            lblWaitingVal.Text = m.WaitingCount.ToString();
            Bar(pbCpu, (int)Math.Round(m.CpuUtilizationPercent));
            Bar(pbMem, (int)Math.Round(m.MemoryUtilizationPercent));
            Bar(pbIo, (int)Math.Round(ioPct));
        }

        private static void Bar(ProgressBar pb, int v)
            => pb.Value = v < 0 ? 0 : v > 100 ? 100 : v;

        // ─────────────────────────────────────────────────────────────────────
        //  GRAPH
        // ─────────────────────────────────────────────────────────────────────
        private void RecordHistory(PerformanceMetrics m)
        {
            double ioPct = m.TotalIoUnits > 0
                           ? m.UsedIoUnits / (double)m.TotalIoUnits * 100.0 : 0;
            Push(_cpuHistory, (int)Math.Round(m.CpuUtilizationPercent));
            Push(_memHistory, (int)Math.Round(m.MemoryUtilizationPercent));
            Push(_ioHistory, (int)Math.Round(ioPct));
        }

        private void Push(List<int> list, int val)
        {
            list.Add(val);
            if (list.Count > MAX_HISTORY) list.RemoveAt(0);
        }

        private void DrawGraph()
        {
            int w = picGraph.Width;
            int h = picGraph.Height;
            if (w < 10 || h < 10) return;

            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.Clear(C_SURFACE2);

                int pad = 28;   // left padding for Y labels
                int graphW = w - pad - 4;
                int graphH = h - 4;

                // Grid lines + Y labels
                using (var gp = new Pen(Color.FromArgb(36, 46, 64), 1))
                using (var lf = new Font("Segoe UI", 6.5f))
                using (var lb = new SolidBrush(C_FG_DIM))
                {
                    foreach (int pct in new[] { 0, 25, 50, 75, 100 })
                    {
                        int y = h - 2 - (int)(pct / 100.0 * graphH);
                        g.DrawLine(gp, pad, y, w - 2, y);
                        g.DrawString(pct + "%", lf, lb, 0, y - 7);
                    }
                }
                
                // Lines
                if (_cpuHistory.Count > 1)
                {
                    DrawLine(g, _cpuHistory, pad, graphW, graphH, C_CPU_LINE);
                    DrawLine(g, _memHistory, pad, graphW, graphH, C_MEM_LINE);
                    DrawLine(g, _ioHistory, pad, graphW, graphH, C_IO_LINE);
                }
                else
                {
                    using var f = new Font("Segoe UI", 8f);
                    using var b = new SolidBrush(C_FG_DIM);
                    string msg = "Run steps to see graph...";
                    var sz = g.MeasureString(msg, f);
                    g.DrawString(msg, f, b, (w - sz.Width) / 2f, (h - sz.Height) / 2f);
                }

                // Inline legend
                DrawLegend(g, pad + 4, 4, "CPU", C_CPU_LINE);
                DrawLegend(g, pad + 48, 4, "MEM", C_MEM_LINE);
                DrawLegend(g, pad + 92, 4, "I/O", C_IO_LINE);
            }

            var old = picGraph.Image;
            picGraph.Image = bmp;
            old?.Dispose();
        }

        private void DrawLine(Graphics g, List<int> data,
                              int padLeft, int graphW, int graphH, Color col)
        {
            if (data.Count < 2) return;
            float stepX = graphW / (float)(MAX_HISTORY - 1);
            var pts = new PointF[data.Count];
            for (int i = 0; i < data.Count; i++)
                pts[i] = new PointF(padLeft + i * stepX,
                                    (graphH + 2) - (data[i] / 100f) * graphH);

            // Fill
            var fill = new PointF[pts.Length + 2];
            fill[0] = new PointF(pts[0].X, graphH + 2);
            for (int i = 0; i < pts.Length; i++) fill[i + 1] = pts[i];
            fill[fill.Length - 1] = new PointF(pts[pts.Length - 1].X, graphH + 2);
            using (var br = new SolidBrush(Color.FromArgb(28, col.R, col.G, col.B)))
                g.FillPolygon(br, fill);

            // Line
            using (var pen = new Pen(col, 1.8f) { LineJoin = LineJoin.Round })
                g.DrawLines(pen, pts);

            // Dot at end
            var last = pts[pts.Length - 1];
            using (var br = new SolidBrush(col))
                g.FillEllipse(br, last.X - 3f, last.Y - 3f, 6f, 6f);
        }

        private void DrawLegend(Graphics g, int x, int y, string text, Color col)
        {
            using var pen = new Pen(col, 2f);
            using var br = new SolidBrush(col);
            using var f = new Font("Segoe UI", 7f, FontStyle.Bold);
            g.DrawLine(pen, x, y + 6, x + 12, y + 6);
            g.DrawString(text, f, br, x + 14, y);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────────────────────────────
        private int SelectedId()
        {
            if (grid.SelectedRows.Count == 0) return -1;
            object v = grid.SelectedRows[0].Cells[0].Value;
            return v is int id ? id : -1;
        }

        private void Log(string msg)
        {
            string ts = DateTime.Now.ToString("HH:mm:ss");
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = C_FG_DIM;
            rtbLog.AppendText("[" + ts + "]  ");
            rtbLog.SelectionColor = C_FG;
            rtbLog.AppendText(msg + "\n");
            rtbLog.ScrollToCaret();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}