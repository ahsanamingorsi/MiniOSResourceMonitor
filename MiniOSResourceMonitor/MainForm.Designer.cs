using System;
using System.Diagnostics.Contracts;
using System.Resources;

namespace MiniOSResourceMonitor
{
   
    partial class MainForm
    {
       
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCPU = new System.Windows.Forms.TextBox();
            this.txtMemory = new System.Windows.Forms.TextBox();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.txtCpuReq = new System.Windows.Forms.TextBox();
            this.txtMemReq = new System.Windows.Forms.TextBox();
            this.txtIoReq = new System.Windows.Forms.TextBox();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblIO = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCPU
            // 
            this.txtCPU.AccessibleName = "txtCPU";
            this.txtCPU.Location = new System.Drawing.Point(12, 28);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.Size = new System.Drawing.Size(100, 20);
            this.txtCPU.TabIndex = 0;
            this.txtCPU.Text = "CPU total";
            // 
            // txtMemory
            // 
            this.txtMemory.AccessibleName = "txtMemory";
            this.txtMemory.Location = new System.Drawing.Point(12, 54);
            this.txtMemory.Name = "txtMemory";
            this.txtMemory.Size = new System.Drawing.Size(100, 20);
            this.txtMemory.TabIndex = 1;
            this.txtMemory.Text = "Memory total";
            this.txtMemory.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtIO
            // 
            this.txtIO.AccessibleName = "txtIO";
            this.txtIO.Location = new System.Drawing.Point(12, 80);
            this.txtIO.Name = "txtIO";
            this.txtIO.Size = new System.Drawing.Size(100, 20);
            this.txtIO.TabIndex = 2;
            this.txtIO.Text = "IO total";
            // 
            // btnConfigure
            // 
            this.btnConfigure.AccessibleName = "btnConfigure";
            this.btnConfigure.Location = new System.Drawing.Point(22, 143);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(100, 23);
            this.btnConfigure.TabIndex = 4;
            this.btnConfigure.Text = "Configure System";
            this.btnConfigure.UseVisualStyleBackColor = true;
            // 
            // txtPid
            // 
            this.txtPid.AccessibleName = "txtPid";
            this.txtPid.Location = new System.Drawing.Point(150, 28);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 20);
            this.txtPid.TabIndex = 5;
            this.txtPid.Text = "Process ID";
            // 
            // txtCpuReq
            // 
            this.txtCpuReq.AccessibleName = "txtCpuReq";
            this.txtCpuReq.Location = new System.Drawing.Point(150, 54);
            this.txtCpuReq.Name = "txtCpuReq";
            this.txtCpuReq.Size = new System.Drawing.Size(100, 20);
            this.txtCpuReq.TabIndex = 6;
            this.txtCpuReq.Text = "CPU Required";
            // 
            // txtMemReq
            // 
            this.txtMemReq.AccessibleName = "txtMemReq";
            this.txtMemReq.Location = new System.Drawing.Point(150, 80);
            this.txtMemReq.Name = "txtMemReq";
            this.txtMemReq.Size = new System.Drawing.Size(100, 20);
            this.txtMemReq.TabIndex = 7;
            this.txtMemReq.Text = "Memory Required";
            // 
            // txtIoReq
            // 
            this.txtIoReq.AccessibleName = "txtIoReq";
            this.txtIoReq.Location = new System.Drawing.Point(150, 108);
            this.txtIoReq.Name = "txtIoReq";
            this.txtIoReq.Size = new System.Drawing.Size(100, 20);
            this.txtIoReq.TabIndex = 8;
            this.txtIoReq.Text = "IO Required";
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.AccessibleName = "btnAddProcess";
            this.btnAddProcess.Location = new System.Drawing.Point(128, 155);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(100, 23);
            this.btnAddProcess.TabIndex = 9;
            this.btnAddProcess.Text = "Add Process";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            // 
            // btnStep
            // 
            this.btnStep.AccessibleName = "btnStep";
            this.btnStep.Location = new System.Drawing.Point(59, 199);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(100, 23);
            this.btnStep.TabIndex = 10;
            this.btnStep.Text = "Simulation Step";
            this.btnStep.UseVisualStyleBackColor = true;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(113, 277);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(57, 13);
            this.lblCPU.TabIndex = 12;
            this.lblCPU.Text = "CPU Used";
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(113, 309);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(72, 13);
            this.lblMemory.TabIndex = 13;
            this.lblMemory.Text = "Memory Used";
            // 
            // lblIO
            // 
            this.lblIO.AutoSize = true;
            this.lblIO.Location = new System.Drawing.Point(113, 370);
            this.lblIO.Name = "lblIO";
            this.lblIO.Size = new System.Drawing.Size(46, 13);
            this.lblIO.TabIndex = 15;
            this.lblIO.Text = "IO Used";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(369, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblIO);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.txtIoReq);
            this.Controls.Add(this.txtMemReq);
            this.Controls.Add(this.txtCpuReq);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.txtIO);
            this.Controls.Add(this.txtMemory);
            this.Controls.Add(this.txtCPU);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.TextBox txtCPU;
        private System.Windows.Forms.TextBox txtMemory;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.TextBox txtCpuReq;
        private System.Windows.Forms.TextBox txtMemReq;
        private System.Windows.Forms.TextBox txtIoReq;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblIO;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
