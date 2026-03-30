using MiniOSResourceMonitor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniOSResourceMonitor.UI
{
    partial class AddProcessForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblIo;
        private System.Windows.Forms.Label lblBurst;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numCpu;
        private System.Windows.Forms.NumericUpDown numMemory;
        private System.Windows.Forms.NumericUpDown numIo;
        private System.Windows.Forms.NumericUpDown numBurst;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblIo = new System.Windows.Forms.Label();
            this.lblBurst = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numCpu = new System.Windows.Forms.NumericUpDown();
            this.numMemory = new System.Windows.Forms.NumericUpDown();
            this.numIo = new System.Windows.Forms.NumericUpDown();
            this.numBurst = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.numCpu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numIo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numBurst).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Process";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Process Name";

            // txtName
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(20, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(360, 23);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "Process";

            // lblCpu
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(20, 106);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(160, 15);
            this.lblCpu.TabIndex = 3;
            this.lblCpu.Text = "CPU Requirement";

            // numCpu
            this.numCpu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCpu.Location = new System.Drawing.Point(20, 124);
            this.numCpu.Name = "numCpu";
            this.numCpu.Size = new System.Drawing.Size(360, 23);
            this.numCpu.TabIndex = 4;

            // lblMemory
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(20, 156);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(180, 15);
            this.lblMemory.TabIndex = 5;
            this.lblMemory.Text = "Memory Requirement";

            // numMemory
            this.numMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMemory.Location = new System.Drawing.Point(20, 174);
            this.numMemory.Name = "numMemory";
            this.numMemory.Size = new System.Drawing.Size(360, 23);
            this.numMemory.TabIndex = 6;

            // lblIo
            this.lblIo.AutoSize = true;
            this.lblIo.Location = new System.Drawing.Point(20, 206);
            this.lblIo.Name = "lblIo";
            this.lblIo.Size = new System.Drawing.Size(160, 15);
            this.lblIo.TabIndex = 7;
            this.lblIo.Text = "I/O Requirement";

            // numIo
            this.numIo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numIo.Location = new System.Drawing.Point(20, 224);
            this.numIo.Name = "numIo";
            this.numIo.Size = new System.Drawing.Size(360, 23);
            this.numIo.TabIndex = 8;

            // lblBurst
            this.lblBurst.AutoSize = true;
            this.lblBurst.Location = new System.Drawing.Point(20, 256);
            this.lblBurst.Name = "lblBurst";
            this.lblBurst.Size = new System.Drawing.Size(160, 15);
            this.lblBurst.TabIndex = 9;
            this.lblBurst.Text = "Burst Time";

            // numBurst
            this.numBurst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBurst.Location = new System.Drawing.Point(20, 274);
            this.numBurst.Name = "numBurst";
            this.numBurst.Size = new System.Drawing.Size(360, 23);
            this.numBurst.TabIndex = 10;
            this.numBurst.Minimum = 1;
            this.numBurst.Maximum = 20;
            this.numBurst.Value = 3;

            // btnOk
            this.btnOk.Location = new System.Drawing.Point(20, 316);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(170, 36);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Add Process";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(210, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // NumericUpDown EndInit
            ((System.ComponentModel.ISupportInitialize)this.numCpu).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numIo).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numBurst).EndInit();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 372);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.numCpu);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.numMemory);
            this.Controls.Add(this.lblIo);
            this.Controls.Add(this.numIo);
            this.Controls.Add(this.lblBurst);
            this.Controls.Add(this.numBurst);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Process";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}