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
            lblAppTitle = new Label();
            lblSubtitle = new Label();
            lblStepDisplay = new Label();
            pnlLegend = new Panel();
            lblLegNew = new Label();
            lblLegReady = new Label();
            lblLegRunning = new Label();
            lblLegWaiting = new Label();
            lblLegTerm = new Label();
            pnlLeft = new Panel();
            pnlPerf = new Panel();
            lblPerfHdr = new Label();
            lblThruTag = new Label();
            lblThroughput = new Label();
            lblWaitTag = new Label();
            lblAvgWait = new Label();
            lblCompTag = new Label();
            lblCompleted = new Label();
            pnlRes = new Panel();
            lblResHdr = new Label();
            lblCpuTag = new Label();
            lblCpuPct = new Label();
            pbCpu = new ProgressBar();
            lblMemTag = new Label();
            lblMemPct = new Label();
            pbMem = new ProgressBar();
            lblIoTag = new Label();
            lblIoPct = new Label();
            pbIo = new ProgressBar();
            lblReadyTag = new Label();
            lblReady = new Label();
            lblRunningTag = new Label();
            lblRunning = new Label();
            lblWaitingTag = new Label();
            lblWaiting = new Label();
            pnlCtrl = new Panel();
            lblCtrlHdr = new Label();
            btnStart = new Button();
            btnStep = new Button();
            btnReset = new Button();
            pnlConfig = new Panel();
            lblConfigHdr = new Label();
            lblCpuLbl = new Label();
            numCpu = new NumericUpDown();
            lblMemLbl = new Label();
            numMemory = new NumericUpDown();
            lblIoLbl = new Label();
            numIo = new NumericUpDown();
            btnApply = new Button();
            pnlRight = new Panel();
            pnlLog = new Panel();
            lblLogHdr = new Label();
            rtbLog = new RichTextBox();
            pnlProc = new Panel();
            lblProcHdr = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            grid = new DataGridView();
            pnlTitle.SuspendLayout();
            pnlLegend.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlPerf.SuspendLayout();
            pnlRes.SuspendLayout();
            pnlCtrl.SuspendLayout();
            pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCpu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIo).BeginInit();
            pnlRight.SuspendLayout();
            pnlLog.SuspendLayout();
            pnlProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.FromArgb(22, 27, 34);
            pnlTitle.Controls.Add(lblAppTitle);
            pnlTitle.Controls.Add(lblSubtitle);
            pnlTitle.Controls.Add(lblStepDisplay);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Margin = new Padding(3, 4, 3, 4);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(1297, 61);
            pnlTitle.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Location = new Point(18, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(182, 20);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Mini OS Resource Monitor";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(297, 20);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(267, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Simulation — no real system data used";
            // 
            // lblStepDisplay
            // 
            lblStepDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStepDisplay.AutoSize = true;
            lblStepDisplay.Location = new Point(2371, 17);
            lblStepDisplay.Name = "lblStepDisplay";
            lblStepDisplay.Size = new Size(54, 20);
            lblStepDisplay.TabIndex = 2;
            lblStepDisplay.Text = "Step: 0";
            // 
            // pnlLegend
            // 
            pnlLegend.BackColor = Color.FromArgb(22, 27, 34);
            pnlLegend.Controls.Add(lblLegNew);
            pnlLegend.Controls.Add(lblLegReady);
            pnlLegend.Controls.Add(lblLegRunning);
            pnlLegend.Controls.Add(lblLegWaiting);
            pnlLegend.Controls.Add(lblLegTerm);
            pnlLegend.Dock = DockStyle.Bottom;
            pnlLegend.Location = new Point(0, 862);
            pnlLegend.Margin = new Padding(3, 4, 3, 4);
            pnlLegend.Name = "pnlLegend";
            pnlLegend.Size = new Size(1297, 35);
            pnlLegend.TabIndex = 1;
            // 
            // lblLegNew
            // 
            lblLegNew.AutoSize = true;
            lblLegNew.Location = new Point(16, 7);
            lblLegNew.Name = "lblLegNew";
            lblLegNew.Size = new Size(52, 20);
            lblLegNew.TabIndex = 0;
            lblLegNew.Text = "● New";
            // 
            // lblLegReady
            // 
            lblLegReady.AutoSize = true;
            lblLegReady.Location = new Point(130, 7);
            lblLegReady.Name = "lblLegReady";
            lblLegReady.Size = new Size(63, 20);
            lblLegReady.TabIndex = 1;
            lblLegReady.Text = "● Ready";
            // 
            // lblLegRunning
            // 
            lblLegRunning.AutoSize = true;
            lblLegRunning.Location = new Point(245, 7);
            lblLegRunning.Name = "lblLegRunning";
            lblLegRunning.Size = new Size(76, 20);
            lblLegRunning.TabIndex = 2;
            lblLegRunning.Text = "● Running";
            // 
            // lblLegWaiting
            // 
            lblLegWaiting.AutoSize = true;
            lblLegWaiting.Location = new Point(359, 7);
            lblLegWaiting.Name = "lblLegWaiting";
            lblLegWaiting.Size = new Size(73, 20);
            lblLegWaiting.TabIndex = 3;
            lblLegWaiting.Text = "● Waiting";
            // 
            // lblLegTerm
            // 
            lblLegTerm.AutoSize = true;
            lblLegTerm.Location = new Point(473, 7);
            lblLegTerm.Name = "lblLegTerm";
            lblLegTerm.Size = new Size(97, 20);
            lblLegTerm.TabIndex = 4;
            lblLegTerm.Text = "● Terminated";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(13, 17, 23);
            pnlLeft.Controls.Add(pnlPerf);
            pnlLeft.Controls.Add(pnlRes);
            pnlLeft.Controls.Add(pnlCtrl);
            pnlLeft.Controls.Add(pnlConfig);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 61);
            pnlLeft.Margin = new Padding(3, 4, 3, 4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(11, 13, 11, 13);
            pnlLeft.Size = new Size(354, 801);
            pnlLeft.TabIndex = 2;
            // 
            // pnlPerf
            // 
            pnlPerf.BackColor = Color.FromArgb(22, 27, 34);
            pnlPerf.Controls.Add(lblPerfHdr);
            pnlPerf.Controls.Add(lblThruTag);
            pnlPerf.Controls.Add(lblThroughput);
            pnlPerf.Controls.Add(lblWaitTag);
            pnlPerf.Controls.Add(lblAvgWait);
            pnlPerf.Controls.Add(lblCompTag);
            pnlPerf.Controls.Add(lblCompleted);
            pnlPerf.Location = new Point(11, 764);
            pnlPerf.Margin = new Padding(3, 4, 3, 4);
            pnlPerf.Name = "pnlPerf";
            pnlPerf.Size = new Size(327, 173);
            pnlPerf.TabIndex = 3;
            // 
            // lblPerfHdr
            // 
            lblPerfHdr.AutoSize = true;
            lblPerfHdr.Location = new Point(16, 13);
            lblPerfHdr.Name = "lblPerfHdr";
            lblPerfHdr.Size = new Size(175, 20);
            lblPerfHdr.TabIndex = 0;
            lblPerfHdr.Text = "PERFORMANCE METRICS";
            // 
            // lblThruTag
            // 
            lblThruTag.AutoSize = true;
            lblThruTag.Location = new Point(16, 48);
            lblThruTag.Name = "lblThruTag";
            lblThruTag.Size = new Size(89, 20);
            lblThruTag.TabIndex = 1;
            lblThruTag.Text = "Throughput:";
            // 
            // lblThroughput
            // 
            lblThroughput.AutoSize = true;
            lblThroughput.Location = new Point(149, 48);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(112, 20);
            lblThroughput.TabIndex = 2;
            lblThroughput.Text = "0.000 proc/step";
            // 
            // lblWaitTag
            // 
            lblWaitTag.AutoSize = true;
            lblWaitTag.Location = new Point(16, 88);
            lblWaitTag.Name = "lblWaitTag";
            lblWaitTag.Size = new Size(109, 20);
            lblWaitTag.TabIndex = 3;
            lblWaitTag.Text = "Avg Wait Time:";
            // 
            // lblAvgWait
            // 
            lblAvgWait.AutoSize = true;
            lblAvgWait.Location = new Point(149, 88);
            lblAvgWait.Name = "lblAvgWait";
            lblAvgWait.Size = new Size(74, 20);
            lblAvgWait.TabIndex = 4;
            lblAvgWait.Text = "0.00 steps";
            // 
            // lblCompTag
            // 
            lblCompTag.AutoSize = true;
            lblCompTag.Location = new Point(16, 128);
            lblCompTag.Name = "lblCompTag";
            lblCompTag.Size = new Size(86, 20);
            lblCompTag.TabIndex = 5;
            lblCompTag.Text = "Completed:";
            // 
            // lblCompleted
            // 
            lblCompleted.AutoSize = true;
            lblCompleted.Location = new Point(149, 128);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(17, 20);
            lblCompleted.TabIndex = 6;
            lblCompleted.Text = "0";
            // 
            // pnlRes
            // 
            pnlRes.BackColor = Color.FromArgb(22, 27, 34);
            pnlRes.Controls.Add(lblResHdr);
            pnlRes.Controls.Add(lblCpuTag);
            pnlRes.Controls.Add(lblCpuPct);
            pnlRes.Controls.Add(pbCpu);
            pnlRes.Controls.Add(lblMemTag);
            pnlRes.Controls.Add(lblMemPct);
            pnlRes.Controls.Add(pbMem);
            pnlRes.Controls.Add(lblIoTag);
            pnlRes.Controls.Add(lblIoPct);
            pnlRes.Controls.Add(pbIo);
            pnlRes.Controls.Add(lblReadyTag);
            pnlRes.Controls.Add(lblReady);
            pnlRes.Controls.Add(lblRunningTag);
            pnlRes.Controls.Add(lblRunning);
            pnlRes.Controls.Add(lblWaitingTag);
            pnlRes.Controls.Add(lblWaiting);
            pnlRes.Location = new Point(11, 504);
            pnlRes.Margin = new Padding(3, 4, 3, 4);
            pnlRes.Name = "pnlRes";
            pnlRes.Size = new Size(327, 247);
            pnlRes.TabIndex = 2;
            // 
            // lblResHdr
            // 
            lblResHdr.AutoSize = true;
            lblResHdr.Location = new Point(16, 13);
            lblResHdr.Name = "lblResHdr";
            lblResHdr.Size = new Size(169, 20);
            lblResHdr.TabIndex = 0;
            lblResHdr.Text = "RESOURCE UTILISATION";
            // 
            // lblCpuTag
            // 
            lblCpuTag.AutoSize = true;
            lblCpuTag.Location = new Point(16, 45);
            lblCpuTag.Name = "lblCpuTag";
            lblCpuTag.Size = new Size(36, 20);
            lblCpuTag.TabIndex = 1;
            lblCpuTag.Text = "CPU";
            // 
            // lblCpuPct
            // 
            lblCpuPct.AutoSize = true;
            lblCpuPct.Location = new Point(251, 43);
            lblCpuPct.Name = "lblCpuPct";
            lblCpuPct.Size = new Size(40, 20);
            lblCpuPct.TabIndex = 2;
            lblCpuPct.Text = "0.0%";
            // 
            // pbCpu
            // 
            pbCpu.Location = new Point(16, 69);
            pbCpu.Margin = new Padding(3, 4, 3, 4);
            pbCpu.Name = "pbCpu";
            pbCpu.Size = new Size(295, 13);
            pbCpu.Style = ProgressBarStyle.Continuous;
            pbCpu.TabIndex = 3;
            // 
            // lblMemTag
            // 
            lblMemTag.AutoSize = true;
            lblMemTag.Location = new Point(16, 96);
            lblMemTag.Name = "lblMemTag";
            lblMemTag.Size = new Size(64, 20);
            lblMemTag.TabIndex = 4;
            lblMemTag.Text = "Memory";
            // 
            // lblMemPct
            // 
            lblMemPct.AutoSize = true;
            lblMemPct.Location = new Point(251, 93);
            lblMemPct.Name = "lblMemPct";
            lblMemPct.Size = new Size(40, 20);
            lblMemPct.TabIndex = 5;
            lblMemPct.Text = "0.0%";
            // 
            // pbMem
            // 
            pbMem.Location = new Point(16, 120);
            pbMem.Margin = new Padding(3, 4, 3, 4);
            pbMem.Name = "pbMem";
            pbMem.Size = new Size(295, 13);
            pbMem.Style = ProgressBarStyle.Continuous;
            pbMem.TabIndex = 6;
            // 
            // lblIoTag
            // 
            lblIoTag.AutoSize = true;
            lblIoTag.Location = new Point(16, 147);
            lblIoTag.Name = "lblIoTag";
            lblIoTag.Size = new Size(30, 20);
            lblIoTag.TabIndex = 7;
            lblIoTag.Text = "I/O";
            // 
            // lblIoPct
            // 
            lblIoPct.AutoSize = true;
            lblIoPct.Location = new Point(251, 144);
            lblIoPct.Name = "lblIoPct";
            lblIoPct.Size = new Size(40, 20);
            lblIoPct.TabIndex = 8;
            lblIoPct.Text = "0.0%";
            // 
            // pbIo
            // 
            pbIo.Location = new Point(16, 168);
            pbIo.Margin = new Padding(3, 4, 3, 4);
            pbIo.Name = "pbIo";
            pbIo.Size = new Size(295, 13);
            pbIo.Style = ProgressBarStyle.Continuous;
            pbIo.TabIndex = 9;
            // 
            // lblReadyTag
            // 
            lblReadyTag.AutoSize = true;
            lblReadyTag.Location = new Point(16, 200);
            lblReadyTag.Name = "lblReadyTag";
            lblReadyTag.Size = new Size(53, 20);
            lblReadyTag.TabIndex = 10;
            lblReadyTag.Text = "Ready:";
            // 
            // lblReady
            // 
            lblReady.AutoSize = true;
            lblReady.Location = new Point(73, 200);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(17, 20);
            lblReady.TabIndex = 11;
            lblReady.Text = "0";
            // 
            // lblRunningTag
            // 
            lblRunningTag.AutoSize = true;
            lblRunningTag.Location = new Point(119, 200);
            lblRunningTag.Name = "lblRunningTag";
            lblRunningTag.Size = new Size(66, 20);
            lblRunningTag.TabIndex = 12;
            lblRunningTag.Text = "Running:";
            // 
            // lblRunning
            // 
            lblRunning.AutoSize = true;
            lblRunning.Location = new Point(192, 200);
            lblRunning.Name = "lblRunning";
            lblRunning.Size = new Size(17, 20);
            lblRunning.TabIndex = 13;
            lblRunning.Text = "0";
            // 
            // lblWaitingTag
            // 
            lblWaitingTag.AutoSize = true;
            lblWaitingTag.Location = new Point(233, 200);
            lblWaitingTag.Name = "lblWaitingTag";
            lblWaitingTag.Size = new Size(63, 20);
            lblWaitingTag.TabIndex = 14;
            lblWaitingTag.Text = "Waiting:";
            // 
            // lblWaiting
            // 
            lblWaiting.AutoSize = true;
            lblWaiting.Location = new Point(295, 200);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(17, 20);
            lblWaiting.TabIndex = 15;
            lblWaiting.Text = "0";
            // 
            // pnlCtrl
            // 
            pnlCtrl.BackColor = Color.FromArgb(22, 27, 34);
            pnlCtrl.Controls.Add(lblCtrlHdr);
            pnlCtrl.Controls.Add(btnStart);
            pnlCtrl.Controls.Add(btnStep);
            pnlCtrl.Controls.Add(btnReset);
            pnlCtrl.Location = new Point(11, 331);
            pnlCtrl.Margin = new Padding(3, 4, 3, 4);
            pnlCtrl.Name = "pnlCtrl";
            pnlCtrl.Size = new Size(327, 160);
            pnlCtrl.TabIndex = 1;
            // 
            // lblCtrlHdr
            // 
            lblCtrlHdr.AutoSize = true;
            lblCtrlHdr.Location = new Point(16, 13);
            lblCtrlHdr.Name = "lblCtrlHdr";
            lblCtrlHdr.Size = new Size(172, 20);
            lblCtrlHdr.TabIndex = 0;
            lblCtrlHdr.Text = "SIMULATION CONTROLS";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(16, 45);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(295, 45);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Simulation";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnStep
            // 
            btnStep.Location = new Point(16, 99);
            btnStep.Margin = new Padding(3, 4, 3, 4);
            btnStep.Name = "btnStep";
            btnStep.Size = new Size(142, 45);
            btnStep.TabIndex = 2;
            btnStep.Text = "Next Step";
            btnStep.UseVisualStyleBackColor = false;
            btnStep.Click += BtnStep_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(169, 99);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(142, 45);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // pnlConfig
            // 
            pnlConfig.BackColor = Color.FromArgb(22, 27, 34);
            pnlConfig.Controls.Add(lblConfigHdr);
            pnlConfig.Controls.Add(lblCpuLbl);
            pnlConfig.Controls.Add(numCpu);
            pnlConfig.Controls.Add(lblMemLbl);
            pnlConfig.Controls.Add(numMemory);
            pnlConfig.Controls.Add(lblIoLbl);
            pnlConfig.Controls.Add(numIo);
            pnlConfig.Controls.Add(btnApply);
            pnlConfig.Location = new Point(11, 13);
            pnlConfig.Margin = new Padding(3, 4, 3, 4);
            pnlConfig.Name = "pnlConfig";
            pnlConfig.Size = new Size(327, 304);
            pnlConfig.TabIndex = 0;
            // 
            // lblConfigHdr
            // 
            lblConfigHdr.AutoSize = true;
            lblConfigHdr.Location = new Point(16, 13);
            lblConfigHdr.Name = "lblConfigHdr";
            lblConfigHdr.Size = new Size(180, 20);
            lblConfigHdr.TabIndex = 0;
            lblConfigHdr.Text = "SYSTEM CONFIGURATION";
            // 
            // lblCpuLbl
            // 
            lblCpuLbl.AutoSize = true;
            lblCpuLbl.Location = new Point(16, 47);
            lblCpuLbl.Name = "lblCpuLbl";
            lblCpuLbl.Size = new Size(121, 20);
            lblCpuLbl.TabIndex = 1;
            lblCpuLbl.Text = "CPU Units (total):";
            // 
            // numCpu
            // 
            numCpu.BorderStyle = BorderStyle.FixedSingle;
            numCpu.Location = new Point(16, 71);
            numCpu.Margin = new Padding(3, 4, 3, 4);
            numCpu.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCpu.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCpu.Name = "numCpu";
            numCpu.Size = new Size(295, 27);
            numCpu.TabIndex = 2;
            numCpu.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblMemLbl
            // 
            lblMemLbl.AutoSize = true;
            lblMemLbl.Location = new Point(16, 111);
            lblMemLbl.Name = "lblMemLbl";
            lblMemLbl.Size = new Size(103, 20);
            lblMemLbl.TabIndex = 3;
            lblMemLbl.Text = "Memory (MB):";
            // 
            // numMemory
            // 
            numMemory.BorderStyle = BorderStyle.FixedSingle;
            numMemory.Location = new Point(16, 135);
            numMemory.Margin = new Padding(3, 4, 3, 4);
            numMemory.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            numMemory.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMemory.Name = "numMemory";
            numMemory.Size = new Size(295, 27);
            numMemory.TabIndex = 4;
            numMemory.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // lblIoLbl
            // 
            lblIoLbl.AutoSize = true;
            lblIoLbl.Location = new Point(16, 175);
            lblIoLbl.Name = "lblIoLbl";
            lblIoLbl.Size = new Size(70, 20);
            lblIoLbl.TabIndex = 5;
            lblIoLbl.Text = "I/O Units:";
            // 
            // numIo
            // 
            numIo.BorderStyle = BorderStyle.FixedSingle;
            numIo.Location = new Point(16, 199);
            numIo.Margin = new Padding(3, 4, 3, 4);
            numIo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIo.Name = "numIo";
            numIo.Size = new Size(295, 27);
            numIo.TabIndex = 6;
            numIo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnApply
            // 
            btnApply.Location = new Point(16, 248);
            btnApply.Margin = new Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(295, 40);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply Config";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += BtnApply_Click;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(13, 17, 23);
            pnlRight.Controls.Add(pnlLog);
            pnlRight.Controls.Add(pnlProc);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(354, 61);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(11, 13, 11, 13);
            pnlRight.Size = new Size(943, 801);
            pnlRight.TabIndex = 3;
            // 
            // pnlLog
            // 
            pnlLog.BackColor = Color.FromArgb(22, 27, 34);
            pnlLog.Controls.Add(lblLogHdr);
            pnlLog.Controls.Add(rtbLog);
            pnlLog.Dock = DockStyle.Bottom;
            pnlLog.Location = new Point(11, 575);
            pnlLog.Margin = new Padding(3, 4, 3, 4);
            pnlLog.Name = "pnlLog";
            pnlLog.Padding = new Padding(9, 8, 9, 8);
            pnlLog.Size = new Size(921, 213);
            pnlLog.TabIndex = 1;
            // 
            // lblLogHdr
            // 
            lblLogHdr.AutoSize = true;
            lblLogHdr.Location = new Point(9, 5);
            lblLogHdr.Name = "lblLogHdr";
            lblLogHdr.Size = new Size(100, 20);
            lblLogHdr.TabIndex = 0;
            lblLogHdr.Text = "ACTIVITY LOG";
            // 
            // rtbLog
            // 
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Bottom;
            rtbLog.Location = new Point(9, 32);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(903, 173);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // pnlProc
            // 
            pnlProc.BackColor = Color.FromArgb(22, 27, 34);
            pnlProc.Controls.Add(lblProcHdr);
            pnlProc.Controls.Add(btnAdd);
            pnlProc.Controls.Add(btnEdit);
            pnlProc.Controls.Add(btnDelete);
            pnlProc.Controls.Add(grid);
            pnlProc.Dock = DockStyle.Fill;
            pnlProc.Location = new Point(11, 13);
            pnlProc.Margin = new Padding(3, 4, 3, 4);
            pnlProc.Name = "pnlProc";
            pnlProc.Padding = new Padding(11, 13, 11, 13);
            pnlProc.Size = new Size(921, 775);
            pnlProc.TabIndex = 0;
            // 
            // lblProcHdr
            // 
            lblProcHdr.AutoSize = true;
            lblProcHdr.Location = new Point(11, 13);
            lblProcHdr.Name = "lblProcHdr";
            lblProcHdr.Size = new Size(115, 20);
            lblProcHdr.TabIndex = 0;
            lblProcHdr.Text = "PROCESS TABLE";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(11, 45);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(101, 37);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(119, 45);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(101, 37);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(226, 45);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 37);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeight = 30;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.Dock = DockStyle.Bottom;
            grid.Location = new Point(11, 255);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(899, 507);
            grid.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 897);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlLegend);
            Controls.Add(pnlTitle);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1255, 944);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini OS Resource Monitor v1.0";
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            pnlLegend.ResumeLayout(false);
            pnlLegend.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlPerf.ResumeLayout(false);
            pnlPerf.PerformLayout();
            pnlRes.ResumeLayout(false);
            pnlRes.PerformLayout();
            pnlCtrl.ResumeLayout(false);
            pnlCtrl.PerformLayout();
            pnlConfig.ResumeLayout(false);
            pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCpu).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIo).EndInit();
            pnlRight.ResumeLayout(false);
            pnlLog.ResumeLayout(false);
            pnlLog.PerformLayout();
            pnlProc.ResumeLayout(false);
            pnlProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        // ── Field declarations ────────────────────────────────────────────────
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
        private System.Windows.Forms.Panel pnlLeft;
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
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblRunningTag;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.Label lblWaitingTag;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Panel pnlPerf;
        private System.Windows.Forms.Label lblPerfHdr;
        private System.Windows.Forms.Label lblThruTag;
        private System.Windows.Forms.Label lblThroughput;
        private System.Windows.Forms.Label lblWaitTag;
        private System.Windows.Forms.Label lblAvgWait;
        private System.Windows.Forms.Label lblCompTag;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlProc;
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