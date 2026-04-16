namespace MiniOSResourceMonitor.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTitle = new Panel();
            lblStepDisplay = new Label();
            lblSubtitle = new Label();
            lblAppTitle = new Label();
            pnlLegend = new Panel();
            lblLegTerm = new Label();
            lblLegWaiting = new Label();
            lblLegRunning = new Label();
            lblLegReady = new Label();
            lblLegNew = new Label();
            tlpMain = new TableLayoutPanel();
            scrlLeft = new Panel();
            pnlGraph = new Panel();
            picGraph = new PictureBox();
            lblGraphHdr = new Label();
            pnlPerf = new Panel();
            lblCompleted = new Label();
            lblCompTag = new Label();
            lblAvgWait = new Label();
            lblWaitTag = new Label();
            lblThroughput = new Label();
            lblThruTag = new Label();
            lblPerfHdr = new Label();
            pnlRes = new Panel();
            lblWaitingVal = new Label();
            lblWaitingTag = new Label();
            lblRunningVal = new Label();
            lblRunningTag = new Label();
            lblReadyVal = new Label();
            lblReadyTag = new Label();
            pbIo = new ProgressBar();
            lblIoPct = new Label();
            lblIoTag = new Label();
            pbMem = new ProgressBar();
            lblMemPct = new Label();
            lblMemTag = new Label();
            pbCpu = new ProgressBar();
            lblCpuPct = new Label();
            lblCpuTag = new Label();
            lblResHdr = new Label();
            pnlCtrl = new Panel();
            btnReset = new Button();
            btnStep = new Button();
            btnStart = new Button();
            lblCtrlHdr = new Label();
            pnlConfig = new Panel();
            btnApply = new Button();
            numIo = new NumericUpDown();
            lblIoLbl = new Label();
            numMemory = new NumericUpDown();
            lblMemLbl = new Label();
            numCpu = new NumericUpDown();
            lblCpuLbl = new Label();
            lblConfigHdr = new Label();
            pnlRight = new Panel();
            grid = new DataGridView();
            pnlLog = new Panel();
            rtbLog = new RichTextBox();
            lblLogHdr = new Label();
            pnlProcBar = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            lblProcHdr = new Label();
            pnlTitle.SuspendLayout();
            pnlLegend.SuspendLayout();
            tlpMain.SuspendLayout();
            scrlLeft.SuspendLayout();
            pnlGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGraph).BeginInit();
            pnlPerf.SuspendLayout();
            pnlRes.SuspendLayout();
            pnlCtrl.SuspendLayout();
            pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCpu).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            pnlLog.SuspendLayout();
            pnlProcBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitle
            // 
            pnlTitle.Controls.Add(lblStepDisplay);
            pnlTitle.Controls.Add(lblSubtitle);
            pnlTitle.Controls.Add(lblAppTitle);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Margin = new Padding(3, 4, 3, 4);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(1463, 69);
            pnlTitle.TabIndex = 0;
            // 
            // lblStepDisplay
            // 
            lblStepDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStepDisplay.Location = new Point(1234, 0);
            lblStepDisplay.Name = "lblStepDisplay";
            lblStepDisplay.Size = new Size(206, 29);
            lblStepDisplay.TabIndex = 2;
            lblStepDisplay.Text = "Step: 0";
            lblStepDisplay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(491, 24);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(389, 24);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Simulation — no real system data used";
            // 
            // lblAppTitle
            // 
            lblAppTitle.Location = new Point(18, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(457, 40);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Mini OS Resource Monitor";
            // 
            // pnlLegend
            // 
            pnlLegend.Controls.Add(lblLegTerm);
            pnlLegend.Controls.Add(lblLegWaiting);
            pnlLegend.Controls.Add(lblLegRunning);
            pnlLegend.Controls.Add(lblLegReady);
            pnlLegend.Controls.Add(lblLegNew);
            pnlLegend.Dock = DockStyle.Bottom;
            pnlLegend.Location = new Point(0, 1015);
            pnlLegend.Margin = new Padding(3, 4, 3, 4);
            pnlLegend.Name = "pnlLegend";
            pnlLegend.Size = new Size(1463, 40);
            pnlLegend.TabIndex = 1;
            // 
            // lblLegTerm
            // 
            lblLegTerm.Location = new Point(453, 9);
            lblLegTerm.Name = "lblLegTerm";
            lblLegTerm.Size = new Size(126, 21);
            lblLegTerm.TabIndex = 4;
            lblLegTerm.Text = "● Terminated";
            // 
            // lblLegWaiting
            // 
            lblLegWaiting.Location = new Point(338, 9);
            lblLegWaiting.Name = "lblLegWaiting";
            lblLegWaiting.Size = new Size(103, 21);
            lblLegWaiting.TabIndex = 3;
            lblLegWaiting.Text = "● Waiting";
            // 
            // lblLegRunning
            // 
            lblLegRunning.Location = new Point(224, 9);
            lblLegRunning.Name = "lblLegRunning";
            lblLegRunning.Size = new Size(103, 21);
            lblLegRunning.TabIndex = 2;
            lblLegRunning.Text = "● Running";
            // 
            // lblLegReady
            // 
            lblLegReady.Location = new Point(121, 9);
            lblLegReady.Name = "lblLegReady";
            lblLegReady.Size = new Size(91, 21);
            lblLegReady.TabIndex = 1;
            lblLegReady.Text = "● Ready";
            // 
            // lblLegNew
            // 
            lblLegNew.Location = new Point(18, 9);
            lblLegNew.Name = "lblLegNew";
            lblLegNew.Size = new Size(91, 21);
            lblLegNew.TabIndex = 0;
            lblLegNew.Text = "● New";
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 366F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(scrlLeft, 0, 0);
            tlpMain.Controls.Add(pnlRight, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 69);
            tlpMain.Margin = new Padding(3, 4, 3, 4);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(7, 8, 7, 8);
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1463, 946);
            tlpMain.TabIndex = 2;
            // 
            // scrlLeft
            // 
            scrlLeft.AutoScroll = true;
            scrlLeft.Controls.Add(pnlGraph);
            scrlLeft.Controls.Add(pnlPerf);
            scrlLeft.Controls.Add(pnlRes);
            scrlLeft.Controls.Add(pnlCtrl);
            scrlLeft.Controls.Add(pnlConfig);
            scrlLeft.Dock = DockStyle.Fill;
            scrlLeft.Location = new Point(10, 12);
            scrlLeft.Margin = new Padding(3, 4, 3, 4);
            scrlLeft.Name = "scrlLeft";
            scrlLeft.Padding = new Padding(0, 0, 5, 0);
            scrlLeft.Size = new Size(360, 922);
            scrlLeft.TabIndex = 0;
            // 
            // pnlGraph
            // 
            pnlGraph.Controls.Add(picGraph);
            pnlGraph.Controls.Add(lblGraphHdr);
            pnlGraph.Location = new Point(0, 925);
            pnlGraph.Margin = new Padding(3, 4, 3, 4);
            pnlGraph.Name = "pnlGraph";
            pnlGraph.Size = new Size(341, 240);
            pnlGraph.TabIndex = 4;
            // 
            // picGraph
            // 
            picGraph.Location = new Point(9, 45);
            picGraph.Margin = new Padding(3, 4, 3, 4);
            picGraph.Name = "picGraph";
            picGraph.Size = new Size(320, 181);
            picGraph.SizeMode = PictureBoxSizeMode.StretchImage;
            picGraph.TabIndex = 1;
            picGraph.TabStop = false;
            // 
            // lblGraphHdr
            // 
            lblGraphHdr.Location = new Point(14, 16);
            lblGraphHdr.Name = "lblGraphHdr";
            lblGraphHdr.Size = new Size(311, 24);
            lblGraphHdr.TabIndex = 0;
            lblGraphHdr.Text = "RESOURCE HISTORY GRAPH";
            // 
            // pnlPerf
            // 
            pnlPerf.Controls.Add(lblCompleted);
            pnlPerf.Controls.Add(lblCompTag);
            pnlPerf.Controls.Add(lblAvgWait);
            pnlPerf.Controls.Add(lblWaitTag);
            pnlPerf.Controls.Add(lblThroughput);
            pnlPerf.Controls.Add(lblThruTag);
            pnlPerf.Controls.Add(lblPerfHdr);
            pnlPerf.Location = new Point(0, 752);
            pnlPerf.Margin = new Padding(3, 4, 3, 4);
            pnlPerf.Name = "pnlPerf";
            pnlPerf.Size = new Size(341, 163);
            pnlPerf.TabIndex = 3;
            // 
            // lblCompleted
            // 
            lblCompleted.Location = new Point(160, 123);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(165, 21);
            lblCompleted.TabIndex = 6;
            lblCompleted.Text = "0";
            // 
            // lblCompTag
            // 
            lblCompTag.Location = new Point(14, 123);
            lblCompTag.Name = "lblCompTag";
            lblCompTag.Size = new Size(114, 21);
            lblCompTag.TabIndex = 5;
            lblCompTag.Text = "Completed:";
            // 
            // lblAvgWait
            // 
            lblAvgWait.Location = new Point(160, 88);
            lblAvgWait.Name = "lblAvgWait";
            lblAvgWait.Size = new Size(165, 21);
            lblAvgWait.TabIndex = 4;
            lblAvgWait.Text = "0.00 steps";
            // 
            // lblWaitTag
            // 
            lblWaitTag.Location = new Point(14, 88);
            lblWaitTag.Name = "lblWaitTag";
            lblWaitTag.Size = new Size(126, 21);
            lblWaitTag.TabIndex = 3;
            lblWaitTag.Text = "Avg Wait Time:";
            // 
            // lblThroughput
            // 
            lblThroughput.Location = new Point(160, 53);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(165, 21);
            lblThroughput.TabIndex = 2;
            lblThroughput.Text = "0.000 proc/step";
            // 
            // lblThruTag
            // 
            lblThruTag.Location = new Point(14, 53);
            lblThruTag.Name = "lblThruTag";
            lblThruTag.Size = new Size(114, 21);
            lblThruTag.TabIndex = 1;
            lblThruTag.Text = "Throughput:";
            // 
            // lblPerfHdr
            // 
            lblPerfHdr.Location = new Point(14, 16);
            lblPerfHdr.Name = "lblPerfHdr";
            lblPerfHdr.Size = new Size(311, 24);
            lblPerfHdr.TabIndex = 0;
            lblPerfHdr.Text = "PERFORMANCE METRICS";
            // 
            // pnlRes
            // 
            pnlRes.Controls.Add(lblWaitingVal);
            pnlRes.Controls.Add(lblWaitingTag);
            pnlRes.Controls.Add(lblRunningVal);
            pnlRes.Controls.Add(lblRunningTag);
            pnlRes.Controls.Add(lblReadyVal);
            pnlRes.Controls.Add(lblReadyTag);
            pnlRes.Controls.Add(pbIo);
            pnlRes.Controls.Add(lblIoPct);
            pnlRes.Controls.Add(lblIoTag);
            pnlRes.Controls.Add(pbMem);
            pnlRes.Controls.Add(lblMemPct);
            pnlRes.Controls.Add(lblMemTag);
            pnlRes.Controls.Add(pbCpu);
            pnlRes.Controls.Add(lblCpuPct);
            pnlRes.Controls.Add(lblCpuTag);
            pnlRes.Controls.Add(lblResHdr);
            pnlRes.Location = new Point(0, 488);
            pnlRes.Margin = new Padding(3, 4, 3, 4);
            pnlRes.Name = "pnlRes";
            pnlRes.Size = new Size(341, 253);
            pnlRes.TabIndex = 2;
            // 
            // lblWaitingVal
            // 
            lblWaitingVal.Location = new Point(297, 221);
            lblWaitingVal.Name = "lblWaitingVal";
            lblWaitingVal.Size = new Size(30, 21);
            lblWaitingVal.TabIndex = 15;
            lblWaitingVal.Text = "0";
            // 
            // lblWaitingTag
            // 
            lblWaitingTag.Location = new Point(231, 221);
            lblWaitingTag.Name = "lblWaitingTag";
            lblWaitingTag.Size = new Size(62, 21);
            lblWaitingTag.TabIndex = 14;
            lblWaitingTag.Text = "Waiting";
            // 
            // lblRunningVal
            // 
            lblRunningVal.Location = new Point(185, 221);
            lblRunningVal.Name = "lblRunningVal";
            lblRunningVal.Size = new Size(30, 21);
            lblRunningVal.TabIndex = 13;
            lblRunningVal.Text = "0";
            // 
            // lblRunningTag
            // 
            lblRunningTag.Location = new Point(114, 221);
            lblRunningTag.Name = "lblRunningTag";
            lblRunningTag.Size = new Size(66, 21);
            lblRunningTag.TabIndex = 12;
            lblRunningTag.Text = "Running";
            // 
            // lblReadyVal
            // 
            lblReadyVal.Location = new Point(69, 221);
            lblReadyVal.Name = "lblReadyVal";
            lblReadyVal.Size = new Size(30, 21);
            lblReadyVal.TabIndex = 11;
            lblReadyVal.Text = "0";
            // 
            // lblReadyTag
            // 
            lblReadyTag.Location = new Point(14, 221);
            lblReadyTag.Name = "lblReadyTag";
            lblReadyTag.Size = new Size(53, 21);
            lblReadyTag.TabIndex = 10;
            lblReadyTag.Text = "Ready";
            // 
            // pbIo
            // 
            pbIo.Location = new Point(14, 188);
            pbIo.Margin = new Padding(3, 4, 3, 4);
            pbIo.Name = "pbIo";
            pbIo.Size = new Size(311, 17);
            pbIo.Style = ProgressBarStyle.Continuous;
            pbIo.TabIndex = 9;
            // 
            // lblIoPct
            // 
            lblIoPct.Location = new Point(256, 163);
            lblIoPct.Name = "lblIoPct";
            lblIoPct.Size = new Size(69, 21);
            lblIoPct.TabIndex = 8;
            lblIoPct.Text = "0.0%";
            lblIoPct.TextAlign = ContentAlignment.TopRight;
            // 
            // lblIoTag
            // 
            lblIoTag.Location = new Point(14, 163);
            lblIoTag.Name = "lblIoTag";
            lblIoTag.Size = new Size(69, 21);
            lblIoTag.TabIndex = 7;
            lblIoTag.Text = "I/O";
            // 
            // pbMem
            // 
            pbMem.Location = new Point(14, 132);
            pbMem.Margin = new Padding(3, 4, 3, 4);
            pbMem.Name = "pbMem";
            pbMem.Size = new Size(311, 17);
            pbMem.Style = ProgressBarStyle.Continuous;
            pbMem.TabIndex = 6;
            // 
            // lblMemPct
            // 
            lblMemPct.Location = new Point(256, 107);
            lblMemPct.Name = "lblMemPct";
            lblMemPct.Size = new Size(69, 21);
            lblMemPct.TabIndex = 5;
            lblMemPct.Text = "0.0%";
            lblMemPct.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMemTag
            // 
            lblMemTag.Location = new Point(14, 107);
            lblMemTag.Name = "lblMemTag";
            lblMemTag.Size = new Size(69, 21);
            lblMemTag.TabIndex = 4;
            lblMemTag.Text = "Memory";
            // 
            // pbCpu
            // 
            pbCpu.Location = new Point(14, 76);
            pbCpu.Margin = new Padding(3, 4, 3, 4);
            pbCpu.Name = "pbCpu";
            pbCpu.Size = new Size(311, 17);
            pbCpu.Style = ProgressBarStyle.Continuous;
            pbCpu.TabIndex = 3;
            // 
            // lblCpuPct
            // 
            lblCpuPct.Location = new Point(256, 51);
            lblCpuPct.Name = "lblCpuPct";
            lblCpuPct.Size = new Size(69, 21);
            lblCpuPct.TabIndex = 2;
            lblCpuPct.Text = "0.0%";
            lblCpuPct.TextAlign = ContentAlignment.TopRight;
            // 
            // lblCpuTag
            // 
            lblCpuTag.Location = new Point(14, 51);
            lblCpuTag.Name = "lblCpuTag";
            lblCpuTag.Size = new Size(69, 21);
            lblCpuTag.TabIndex = 1;
            lblCpuTag.Text = "CPU";
            // 
            // lblResHdr
            // 
            lblResHdr.Location = new Point(14, 16);
            lblResHdr.Name = "lblResHdr";
            lblResHdr.Size = new Size(311, 24);
            lblResHdr.TabIndex = 0;
            lblResHdr.Text = "RESOURCE UTILISATION";
            // 
            // pnlCtrl
            // 
            pnlCtrl.Controls.Add(btnReset);
            pnlCtrl.Controls.Add(btnStep);
            pnlCtrl.Controls.Add(btnStart);
            pnlCtrl.Controls.Add(lblCtrlHdr);
            pnlCtrl.Location = new Point(0, 320);
            pnlCtrl.Margin = new Padding(3, 4, 3, 4);
            pnlCtrl.Name = "pnlCtrl";
            pnlCtrl.Size = new Size(341, 157);
            pnlCtrl.TabIndex = 1;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(176, 99);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(149, 43);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // btnStep
            // 
            btnStep.Location = new Point(14, 99);
            btnStep.Margin = new Padding(3, 4, 3, 4);
            btnStep.Name = "btnStep";
            btnStep.Size = new Size(149, 43);
            btnStep.TabIndex = 2;
            btnStep.Text = "Next Step";
            btnStep.UseVisualStyleBackColor = false;
            btnStep.Click += BtnStep_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(14, 48);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(311, 43);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Simulation";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // lblCtrlHdr
            // 
            lblCtrlHdr.Location = new Point(14, 16);
            lblCtrlHdr.Name = "lblCtrlHdr";
            lblCtrlHdr.Size = new Size(311, 24);
            lblCtrlHdr.TabIndex = 0;
            lblCtrlHdr.Text = "SIMULATION CONTROLS";
            // 
            // pnlConfig
            // 
            pnlConfig.Controls.Add(btnApply);
            pnlConfig.Controls.Add(numIo);
            pnlConfig.Controls.Add(lblIoLbl);
            pnlConfig.Controls.Add(numMemory);
            pnlConfig.Controls.Add(lblMemLbl);
            pnlConfig.Controls.Add(numCpu);
            pnlConfig.Controls.Add(lblCpuLbl);
            pnlConfig.Controls.Add(lblConfigHdr);
            pnlConfig.Location = new Point(0, 0);
            pnlConfig.Margin = new Padding(3, 4, 3, 4);
            pnlConfig.Name = "pnlConfig";
            pnlConfig.Size = new Size(341, 309);
            pnlConfig.TabIndex = 0;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(14, 256);
            btnApply.Margin = new Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(311, 43);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply Config";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += BtnApply_Click;
            // 
            // numIo
            // 
            numIo.BorderStyle = BorderStyle.FixedSingle;
            numIo.Location = new Point(14, 208);
            numIo.Margin = new Padding(3, 4, 3, 4);
            numIo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIo.Name = "numIo";
            numIo.Size = new Size(311, 27);
            numIo.TabIndex = 6;
            numIo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblIoLbl
            // 
            lblIoLbl.Location = new Point(14, 184);
            lblIoLbl.Name = "lblIoLbl";
            lblIoLbl.Size = new Size(229, 21);
            lblIoLbl.TabIndex = 5;
            lblIoLbl.Text = "I/O Units";
            // 
            // numMemory
            // 
            numMemory.BorderStyle = BorderStyle.FixedSingle;
            numMemory.Location = new Point(14, 141);
            numMemory.Margin = new Padding(3, 4, 3, 4);
            numMemory.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            numMemory.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMemory.Name = "numMemory";
            numMemory.Size = new Size(311, 27);
            numMemory.TabIndex = 4;
            numMemory.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // lblMemLbl
            // 
            lblMemLbl.Location = new Point(14, 117);
            lblMemLbl.Name = "lblMemLbl";
            lblMemLbl.Size = new Size(229, 21);
            lblMemLbl.TabIndex = 3;
            lblMemLbl.Text = "Memory (MB)";
            // 
            // numCpu
            // 
            numCpu.BorderStyle = BorderStyle.FixedSingle;
            numCpu.Location = new Point(14, 75);
            numCpu.Margin = new Padding(3, 4, 3, 4);
            numCpu.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCpu.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCpu.Name = "numCpu";
            numCpu.Size = new Size(311, 27);
            numCpu.TabIndex = 2;
            numCpu.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblCpuLbl
            // 
            lblCpuLbl.Location = new Point(14, 51);
            lblCpuLbl.Name = "lblCpuLbl";
            lblCpuLbl.Size = new Size(229, 21);
            lblCpuLbl.TabIndex = 1;
            lblCpuLbl.Text = "CPU Units (total)";
            // 
            // lblConfigHdr
            // 
            lblConfigHdr.Location = new Point(14, 16);
            lblConfigHdr.Name = "lblConfigHdr";
            lblConfigHdr.Size = new Size(311, 24);
            lblConfigHdr.TabIndex = 0;
            lblConfigHdr.Text = "SYSTEM CONFIGURATION";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grid);
            pnlRight.Controls.Add(pnlLog);
            pnlRight.Controls.Add(pnlProcBar);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(376, 12);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1077, 922);
            pnlRight.TabIndex = 1;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeight = 34;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 69);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(1077, 640);
            grid.TabIndex = 1;
            grid.CellContentClick += grid_CellContentClick;
            // 
            // pnlLog
            // 
            pnlLog.Controls.Add(rtbLog);
            pnlLog.Controls.Add(lblLogHdr);
            pnlLog.Dock = DockStyle.Bottom;
            pnlLog.Location = new Point(0, 709);
            pnlLog.Margin = new Padding(3, 4, 3, 4);
            pnlLog.Name = "pnlLog";
            pnlLog.Size = new Size(1077, 213);
            pnlLog.TabIndex = 2;
            // 
            // rtbLog
            // 
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Bottom;
            rtbLog.Location = new Point(0, 42);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(1077, 171);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // lblLogHdr
            // 
            lblLogHdr.Location = new Point(14, 8);
            lblLogHdr.Name = "lblLogHdr";
            lblLogHdr.Size = new Size(229, 27);
            lblLogHdr.TabIndex = 0;
            lblLogHdr.Text = "ACTIVITY LOG";
            // 
            // pnlProcBar
            // 
            pnlProcBar.Controls.Add(btnDelete);
            pnlProcBar.Controls.Add(btnEdit);
            pnlProcBar.Controls.Add(btnAdd);
            pnlProcBar.Controls.Add(lblProcHdr);
            pnlProcBar.Dock = DockStyle.Top;
            pnlProcBar.Location = new Point(0, 0);
            pnlProcBar.Margin = new Padding(3, 4, 3, 4);
            pnlProcBar.Name = "pnlProcBar";
            pnlProcBar.Size = new Size(1077, 69);
            pnlProcBar.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(849, 0);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 43);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Location = new Point(849, 0);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 43);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(849, 0);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 43);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // lblProcHdr
            // 
            lblProcHdr.Location = new Point(14, 21);
            lblProcHdr.Name = "lblProcHdr";
            lblProcHdr.Size = new Size(274, 27);
            lblProcHdr.TabIndex = 0;
            lblProcHdr.Text = "PROCESS TABLE";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 1055);
            Controls.Add(tlpMain);
            Controls.Add(pnlLegend);
            Controls.Add(pnlTitle);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 784);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini OS Resource Monitor  v1.0";
            pnlTitle.ResumeLayout(false);
            pnlLegend.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            scrlLeft.ResumeLayout(false);
            pnlGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGraph).EndInit();
            pnlPerf.ResumeLayout(false);
            pnlRes.ResumeLayout(false);
            pnlCtrl.ResumeLayout(false);
            pnlConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numIo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCpu).EndInit();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            pnlLog.ResumeLayout(false);
            pnlProcBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ── Field declarations ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblStepDisplay;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblLegNew;
        private System.Windows.Forms.Label lblLegReady;
        private System.Windows.Forms.Label lblLegRunning;
        private System.Windows.Forms.Label lblLegWaiting;
        private System.Windows.Forms.Label lblLegTerm;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel scrlLeft;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblConfigHdr;
        private System.Windows.Forms.Label lblCpuLbl;
        private System.Windows.Forms.NumericUpDown numCpu;
        private System.Windows.Forms.Label lblMemLbl;
        private System.Windows.Forms.NumericUpDown numMemory;
        private System.Windows.Forms.Label lblIoLbl;
        private System.Windows.Forms.NumericUpDown numIo;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Label lblCtrlHdr;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.Label lblResHdr;
        private System.Windows.Forms.Label lblCpuTag;
        private System.Windows.Forms.Label lblCpuPct;
        private System.Windows.Forms.ProgressBar pbCpu;
        private System.Windows.Forms.Label lblMemTag;
        private System.Windows.Forms.Label lblMemPct;
        private System.Windows.Forms.ProgressBar pbMem;
        private System.Windows.Forms.Label lblIoTag;
        private System.Windows.Forms.Label lblIoPct;
        private System.Windows.Forms.ProgressBar pbIo;
        private System.Windows.Forms.Label lblReadyTag;
        private System.Windows.Forms.Label lblReadyVal;
        private System.Windows.Forms.Label lblRunningTag;
        private System.Windows.Forms.Label lblRunningVal;
        private System.Windows.Forms.Label lblWaitingTag;
        private System.Windows.Forms.Label lblWaitingVal;
        private System.Windows.Forms.Panel pnlPerf;
        private System.Windows.Forms.Label lblPerfHdr;
        private System.Windows.Forms.Label lblThruTag;
        private System.Windows.Forms.Label lblThroughput;
        private System.Windows.Forms.Label lblWaitTag;
        private System.Windows.Forms.Label lblAvgWait;
        private System.Windows.Forms.Label lblCompTag;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.Label lblGraphHdr;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlProcBar;
        private System.Windows.Forms.Label lblProcHdr;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogHdr;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}