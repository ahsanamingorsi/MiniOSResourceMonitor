using Microsoft.VisualBasic.Devices;
using MiniOSResourceMonitor.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MiniOSResourceMonitor.UI
{
    public partial class AddProcessForm : Form
    {
        // ── Theme colours ─────────────────────────────────────────────────────
        internal static readonly Color C_BG = Color.FromArgb(18, 18, 18);
        internal static readonly Color C_ACCENT = Color.FromArgb(99, 179, 237);
        internal static readonly Color C_FG = Color.FromArgb(220, 220, 220);
        internal static readonly Color C_INPUT_BG = Color.FromArgb(45, 45, 45);
        internal static readonly Color C_BTN_OK = Color.FromArgb(35, 134, 54);
        internal static readonly Color C_BTN_CAN = Color.FromArgb(180, 60, 60);

        // ── State ─────────────────────────────────────────────────────────────
        private readonly OsProcess? _editTarget;
        private readonly int _maxCpu;
        private readonly int _maxMemory;
        private readonly int _maxIo;

        public OsProcess? Result { get; private set; }

        public AddProcessForm(int maxCpu, int maxMemory, int maxIo,
                              OsProcess? editTarget = null)
        {
            _maxCpu = maxCpu;
            _maxMemory = maxMemory;
            _maxIo = maxIo;
            _editTarget = editTarget;

            InitializeComponent();
            ApplyTheme();

            if (_editTarget != null)
                PopulateForEdit(_editTarget);
        }

        // ── Apply dark theme after Designer init ──────────────────────────────
        private void ApplyTheme()
        {
            BackColor = C_BG;
            ForeColor = C_FG;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.ForeColor = C_ACCENT;
            lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitle.Text = _editTarget == null ? "➕  New Process" : "✏️  Edit Process";

            Text = _editTarget == null ? "Add New Process" : "Edit Process";

            // Input fields
            foreach (Control c in new Control[]
                     { txtName, numCpu, numMemory, numIo, numBurst })
            {
                c.BackColor = C_INPUT_BG;
                c.ForeColor = C_FG;
            }

            // Labels
            foreach (Control c in new Control[]
                     { lblName, lblCpu, lblMemory, lblIo, lblBurst })
            {
                c.ForeColor = Color.FromArgb(160, 160, 160);
            }

            // Range hints
            lblCpu.Text = $"CPU Requirement  (1 – {_maxCpu} units)";
            lblMemory.Text = $"Memory Requirement  (1 – {_maxMemory} MB)";
            lblIo.Text = $"I/O Requirement  (0 = no I/O,  max {_maxIo})";
            lblBurst.Text = "Burst Time  (simulation steps to complete)";

            // Spinner limits
            numCpu.Minimum = 1; numCpu.Maximum = _maxCpu;
            numCpu.Value = Math.Min(10, _maxCpu);

            numMemory.Minimum = 1; numMemory.Maximum = _maxMemory;
            numMemory.Value = Math.Min(128, _maxMemory);

            numIo.Minimum = 0; numIo.Maximum = _maxIo;
            numIo.Value = 0;

            numBurst.Minimum = 1; numBurst.Maximum = 20;
            numBurst.Value = 3;

            // Buttons
            btnOk.BackColor = C_BTN_OK;
            btnOk.ForeColor = Color.White;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnOk.Text = _editTarget == null ? "Add Process" : "Save Changes";
            btnOk.Cursor = Cursors.Hand;

            btnCancel.BackColor = C_BTN_CAN;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;
        }

        // ── Populate fields when editing ──────────────────────────────────────
        private void PopulateForEdit(OsProcess p)
        {
            txtName.Text = p.Name;
            numCpu.Value = Math.Min(p.CpuRequirement, numCpu.Maximum);
            numMemory.Value = Math.Min(p.MemoryRequirementMB, numMemory.Maximum);
            numIo.Value = Math.Min(p.IoRequirement, numIo.Maximum);
            numBurst.Value = Math.Min(p.RemainingBurstTime, numBurst.Maximum);
        }

        // ── Button events ─────────────────────────────────────────────────────
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Process name cannot be empty.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new OsProcess
            {
                ProcessId = _editTarget != null ? _editTarget.ProcessId : 0,
                Name = txtName.Text.Trim(),
                CpuRequirement = (int)numCpu.Value,
                MemoryRequirementMB = (int)numMemory.Value,
                IoRequirement = (int)numIo.Value,
                RemainingBurstTime = (int)numBurst.Value,
                State = _editTarget != null
                                          ? _editTarget.State
                                          : ProcessState.New
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Result = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}