using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniOSResourceMonitor.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  HELPER FACTORIES
        // ─────────────────────────────────────────────────────────────────────
        private Panel MakePanel(int x, int y, int w, int h)
        {
            var p = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = C_SURFACE,
            };
            p.Paint += PanelBorder_Paint;
            return p;
        }

        private Label MakeHeader(string text, int x = 14, int y = 10)
            => new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = C_ACCENT,
                Location = new Point(x, y),
                AutoSize = true,
                BackColor = Color.Transparent
            };

        private Label MakeDimLabel(string text, int x, int y, int w = 120)
            => new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8f),
                ForeColor = C_FG_DIM,
                Location = new Point(x, y),
                Size = new Size(w, 18),
                BackColor = Color.Transparent
            };

        private Label MakeValueLabel(int x, int y, int w = 90)
            => new Label
            {
                Text = "—",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = C_FG,
                Location = new Point(x, y),
                Size = new Size(w, 22),
                BackColor = Color.Transparent
            };

        private Button MakeButton(string text, Color back, int x, int y, int w, int h)
        {
            var b = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(x, y),
                Size = new Size(w, h),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(back, 0.15f);
            return b;
        }

        private NumericUpDown MakeNumeric(int x, int y, int w,
                                          int min, int max, int val)
            => new NumericUpDown
            {
                Location = new Point(x, y),
                Size = new Size(w, 26),
                Minimum = min,
                Maximum = max,
                Value = val,
                BackColor = C_INPUT,
                ForeColor = C_FG,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9f)
            };

        private ProgressBar MakeBar(int x, int y, int w)
        {
            var pb = new ProgressBar
            {
                Location = new Point(x, y),
                Size = new Size(w, 10),
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Style = ProgressBarStyle.Continuous
            };
            return pb;
        }

        private static void PanelBorder_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            using var pen = new Pen(C_BORDER, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  InitializeComponent
        // ─────────────────────────────────────────────────────────────────────
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── Form ──────────────────────────────────────────────────────────
            Text = "Mini OS Resource Monitor  v1.0";
            Size = new Size(1280, 820);
            MinimumSize = new Size(1100, 720);
            BackColor = C_BG;
            ForeColor = C_FG;
            Font = new Font("Segoe UI", 9f);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;

            // ══════════════════════════════════════════════════════════════════
            //  TITLE BAR STRIP
            // ══════════════════════════════════════════════════════════════════
            var titleBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = C_SURFACE
            };
            titleBar.Paint += PanelBorder_Paint;

            var lblTitle = new Label
            {
                Text = "⚙  Mini OS Resource Monitor",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = C_ACCENT,
                Location = new Point(16, 10),
                AutoSize = true
            };
            var lblSub = new Label
            {
                Text = "Simulation — no real system data used",
                Font = new Font("Segoe UI", 8f),
                ForeColor = C_FG_DIM,
                Location = new Point(280, 15),
                AutoSize = true
            };
            _lblStep = new Label
            {
                Text = "Step: 0",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = C_ACCENT2,
                AutoSize = true
            };
            _lblStep.Location = new Point(titleBar.Width - 120, 13);
            _lblStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            titleBar.Controls.AddRange(new Control[] { lblTitle, lblSub, _lblStep });

            // ══════════════════════════════════════════════════════════════════
            //  MAIN CONTENT  (left + right columns inside a TableLayoutPanel)
            // ══════════════════════════════════════════════════════════════════
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = C_BG,
                Padding = new Padding(10)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 310));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ── LEFT COLUMN ───────────────────────────────────────────────────
            var leftCol = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

            // ┌─ System Config ─────────────────────────────────────────────┐
            var pnlConfig = MakePanel(0, 0, 290, 168);
            pnlConfig.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            pnlConfig.Controls.Add(MakeHeader("⚙  SYSTEM CONFIGURATION"));
            pnlConfig.Controls.Add(MakeDimLabel("CPU Units (total):", 14, 35));
            _numCpu = MakeNumeric(14, 54, 260, 1, 1000, 100);
            pnlConfig.Controls.Add(_numCpu);

            pnlConfig.Controls.Add(MakeDimLabel("Memory (MB):", 14, 84));
            _numMemory = MakeNumeric(14, 103, 260, 1, 65536, 1024);
            pnlConfig.Controls.Add(_numMemory);

            pnlConfig.Controls.Add(MakeDimLabel("I/O Units:", 14, 133));
            _numIo = MakeNumeric(14, 152, 260, 1, 100, 10);
            pnlConfig.Controls.Add(_numIo);

            // Resize panel to fit controls
            pnlConfig.Height = 200;

            _btnApply = MakeButton("Apply Config", C_BTN_ADD, 14, 186, 260, 30);
            pnlConfig.Controls.Add(_btnApply);
            pnlConfig.Height = 228;

            leftCol.Controls.Add(pnlConfig);

            // ┌─ Simulation Controls ───────────────────────────────────────┐
            var pnlCtrl = MakePanel(0, 238, 290, 126);
            pnlCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCtrl.Controls.Add(MakeHeader("▶  SIMULATION CONTROLS"));

            _btnStart = MakeButton("▶  Start Simulation", C_BTN_START, 14, 34, 260, 34);
            _btnStep = MakeButton("⏭  Next Step", C_BTN_STEP, 14, 74, 124, 34);
            _btnReset = MakeButton("🔄  Reset", C_BTN_RESET, 150, 74, 124, 34);

            pnlCtrl.Controls.AddRange(new Control[] { _btnStart, _btnStep, _btnReset });
            leftCol.Controls.Add(pnlCtrl);

            // ┌─ Resource Utilisation ──────────────────────────────────────┐
            var pnlRes = MakePanel(0, 374, 290, 192);
            pnlRes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRes.Controls.Add(MakeHeader("📊  RESOURCE UTILISATION"));

            // CPU row
            pnlRes.Controls.Add(MakeDimLabel("CPU", 14, 36));
            _lblCpuPct = MakeValueLabel(220, 32, 60);
            _pbCpu = MakeBar(14, 54, 260);
            pnlRes.Controls.Add(_lblCpuPct);
            pnlRes.Controls.Add(_pbCpu);

            // Memory row
            pnlRes.Controls.Add(MakeDimLabel("Memory", 14, 76));
            _lblMemPct = MakeValueLabel(220, 72, 60);
            _pbMem = MakeBar(14, 94, 260);
            pnlRes.Controls.Add(_lblMemPct);
            pnlRes.Controls.Add(_pbMem);

            // I/O row
            pnlRes.Controls.Add(MakeDimLabel("I/O", 14, 116));
            _lblIoPct = MakeValueLabel(220, 112, 60);
            _pbIo = MakeBar(14, 134, 260);
            pnlRes.Controls.Add(_lblIoPct);
            pnlRes.Controls.Add(_pbIo);

            // Queue counts
            pnlRes.Controls.Add(MakeDimLabel("Ready:", 14, 154));
            _lblReady = MakeValueLabel(70, 150, 40);
            pnlRes.Controls.Add(MakeDimLabel("Running:", 110, 154));
            _lblRunning = MakeValueLabel(174, 150, 40);
            pnlRes.Controls.Add(MakeDimLabel("Waiting:", 214, 154, 55));
            _lblWaiting = MakeValueLabel(252, 150, 34);

            _lblReady.Font = _lblRunning.Font = _lblWaiting.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            _lblReady.ForeColor = C_READY;
            _lblRunning.ForeColor = C_RUNNING;
            _lblWaiting.ForeColor = C_WAITING;

            pnlRes.Controls.AddRange(new Control[] { _lblReady, _lblRunning, _lblWaiting });
            leftCol.Controls.Add(pnlRes);

            // ┌─ Performance Metrics ───────────────────────────────────────┐
            var pnlPerf = MakePanel(0, 576, 290, 154);
            pnlPerf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPerf.Controls.Add(MakeHeader("📈  PERFORMANCE METRICS"));

            pnlPerf.Controls.Add(MakeDimLabel("Throughput:", 14, 36));
            _lblThroughput = MakeValueLabel(130, 32, 150);
            pnlPerf.Controls.Add(_lblThroughput);

            pnlPerf.Controls.Add(MakeDimLabel("Avg Waiting Time:", 14, 68));
            _lblAvgWait = MakeValueLabel(148, 64, 132);
            pnlPerf.Controls.Add(_lblAvgWait);

            pnlPerf.Controls.Add(MakeDimLabel("Completed:", 14, 100));
            _lblCompleted = MakeValueLabel(130, 96, 60);
            pnlPerf.Controls.Add(_lblCompleted);

            leftCol.Controls.Add(pnlPerf);

            tlp.Controls.Add(leftCol, 0, 0);

            // ── RIGHT COLUMN ──────────────────────────────────────────────────
            var rightCol = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

            // ┌─ Process Management ────────────────────────────────────────┐
            var pnlProc = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = C_SURFACE,
                Padding = new Padding(14, 10, 14, 10)
            };
            pnlProc.Paint += PanelBorder_Paint;

            // Header row
            var hdrRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.Transparent
            };
            hdrRow.Controls.Add(MakeHeader("🗂  PROCESS TABLE  (click row to select)", 0, 8));

            _btnAdd = MakeButton("➕ Add", C_BTN_ADD, 150, 4, 90, 30);
            _btnEdit = MakeButton("✏ Edit", C_BTN_EDIT, 248, 4, 90, 30);
            _btnDelete = MakeButton("🗑 Delete", C_BTN_DEL, 346, 4, 90, 30);
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hdrRow.Controls.AddRange(new Control[] { _btnAdd, _btnEdit, _btnDelete });
            pnlProc.Controls.Add(hdrRow);

            // DataGridView
            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = C_SURFACE2,
                GridColor = C_BORDER,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Consolas", 9f),
                ColumnHeadersHeight = 30,
                RowTemplate = { Height = 28 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };

            // Grid styles
            _grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE2,
                ForeColor = C_FG,
                SelectionBackColor = Color.FromArgb(40, 88, 166, 255),
                SelectionForeColor = C_FG,
                Padding = new Padding(4, 0, 4, 0)
            };
            _grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = C_SURFACE,
                ForeColor = C_ACCENT,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Padding = new Padding(4, 4, 4, 4),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            _grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(26, 32, 40)
            };
            _grid.EnableHeadersVisualStyles = false;

            // Columns
            string[] colNames = { "PID", "Name", "CPU", "Memory (MB)", "I/O", "Burst Left", "Wait Steps", "State" };
            int[] colWidths = { 45, 140, 50, 90, 40, 70, 70, 80 };
            for (int i = 0; i < colNames.Length; i++)
            {
                _grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = colNames[i],
                    ReadOnly = true,
                    FillWeight = colWidths[i],
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            pnlProc.Controls.Add(_grid);

            // ┌─ Activity Log ──────────────────────────────────────────────┐
            var logPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 160,
                BackColor = C_SURFACE,
                Padding = new Padding(10, 6, 10, 6)
            };
            logPanel.Paint += PanelBorder_Paint;

            logPanel.Controls.Add(MakeHeader("📋  ACTIVITY LOG", 6, 4));

            _log = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = C_SURFACE,
                ForeColor = C_FG,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Font = new Font("Consolas", 8.5f),
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            logPanel.Controls.Add(_log);

            rightCol.Controls.Add(logPanel);
            rightCol.Controls.Add(pnlProc);

            tlp.Controls.Add(rightCol, 1, 0);

            // ── Assemble form ─────────────────────────────────────────────────
            Controls.Add(tlp);
            Controls.Add(titleBar);

            // ── Legend strip (bottom) ─────────────────────────────────────────
            var legend = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                BackColor = C_SURFACE
            };
            legend.Paint += PanelBorder_Paint;

            int lx = 14;
            foreach (var (label, color) in new (string, Color)[]
            {
                ("● New",       C_NEW),
                ("● Ready",     C_READY),
                ("● Running",   C_RUNNING),
                ("● Waiting",   C_WAITING),
                ("● Terminated",C_TERMINATED)
            })
            {
                legend.Controls.Add(new Label
                {
                    Text = label,
                    ForeColor = color,
                    Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                    Location = new Point(lx, 5),
                    AutoSize = true,
                    BackColor = Color.Transparent
                });
                lx += 100;
            }
            Controls.Add(legend);
        }
    }
}
