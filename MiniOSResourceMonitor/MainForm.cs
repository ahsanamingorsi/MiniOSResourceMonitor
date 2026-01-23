using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MiniOSResourceMonitor
{
    public partial class MainForm : Form
    {
        private SystemConfig _systemConfig;
        private ResourceStatus _resourceStatus;
        private ResourceManager _resourceManager;
        private ProcessController _processController;
        private SimulationEngine _simulationEngine;

        public MainForm()
        {
            InitializeComponent();
            _systemConfig = new SystemConfig();
            _resourceStatus = new ResourceStatus();
            _resourceManager = new ResourceManager(_systemConfig, _resourceStatus);
            _processController = new ProcessController(_resourceManager);
            _simulationEngine = new SimulationEngine(_processController);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnConfigure_Click(object sender, EventArgs e)
        {
            _systemConfig.TotalCPU = int.Parse(txtCPU.Text);
            _systemConfig.TotalMemory = int.Parse(txtMemory.Text);
            _systemConfig.TotalIO = int.Parse(txtIO.Text);

            _systemConfig.IsConfigured = true;
        }
        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            if (!_systemConfig.IsConfigured)
                return;

            ProcessModel process = new ProcessModel
            {
                ProcessId = int.Parse(txtPid.Text),
                CpuRequired = int.Parse(txtCpuReq.Text),
                MemoryRequired = int.Parse(txtMemReq.Text),
                IoRequired = int.Parse(txtIoReq.Text)
            };

            _processController.AddProcess(process);
            RefreshProcessTable();
        }
        private void btnStep_Click(object sender, EventArgs e)
        {
            if (!_systemConfig.IsConfigured)
                return;

            _simulationEngine.Step();
            RefreshProcessTable();
            RefreshResourceDisplay();
        }
      
        private void RefreshResourceDisplay()
        {
            lblCPU.Text = _resourceStatus.UsedCPU.ToString();
            lblMemory.Text = _resourceStatus.UsedMemory.ToString();
            lblIO.Text = _resourceStatus.UsedIO.ToString();
        }

        private void RefreshProcessTable()
        {
            var displayList = _processController.GetAllProcesses()
                .Select(p => new ProcessDisplay
                {
                    ProcessID = p.ProcessId,
                    CPU = p.CpuRequired,
                    Memory = p.MemoryRequired,
                    IO = p.IoRequired,
                    State = p.State.ToString(),
                    WaitingTime = p.WaitingTime,
                    TurnaroundTime = p.TurnaroundTime
                }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = displayList;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
