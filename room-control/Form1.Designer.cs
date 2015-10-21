namespace RoomControl
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPC = new System.Windows.Forms.DataGridView();
            this.dgvMonitor = new System.Windows.Forms.DataGridView();
            this.dgvProjector = new System.Windows.Forms.DataGridView();
            this.dgvrPcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrPcStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrMonitorPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorInput = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrProjectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrProjectorStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.pCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PCs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monitors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Projectors";
            // 
            // dgvPC
            // 
            this.dgvPC.AllowUserToAddRows = false;
            this.dgvPC.AllowUserToDeleteRows = false;
            this.dgvPC.AllowUserToResizeRows = false;
            this.dgvPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrPcName,
            this.dgvrPcStatus});
            this.dgvPC.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pCBindingSource, "Name", true));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPC.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPC.Location = new System.Drawing.Point(13, 38);
            this.dgvPC.Name = "dgvPC";
            this.dgvPC.ReadOnly = true;
            this.dgvPC.RowHeadersVisible = false;
            this.dgvPC.Size = new System.Drawing.Size(193, 354);
            this.dgvPC.TabIndex = 6;
            // 
            // dgvMonitor
            // 
            this.dgvMonitor.AllowUserToAddRows = false;
            this.dgvMonitor.AllowUserToDeleteRows = false;
            this.dgvMonitor.AllowUserToResizeRows = false;
            this.dgvMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrMonitorName,
            this.dgvrMonitorPower,
            this.dgvrMonitorInput});
            this.dgvMonitor.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pCBindingSource, "Name", true));
            this.dgvMonitor.Location = new System.Drawing.Point(245, 38);
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.ReadOnly = true;
            this.dgvMonitor.RowHeadersVisible = false;
            this.dgvMonitor.Size = new System.Drawing.Size(244, 354);
            this.dgvMonitor.TabIndex = 7;
            // 
            // dgvProjector
            // 
            this.dgvProjector.AllowUserToAddRows = false;
            this.dgvProjector.AllowUserToDeleteRows = false;
            this.dgvProjector.AllowUserToResizeRows = false;
            this.dgvProjector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrProjectorName,
            this.dgvrProjectorStatus});
            this.dgvProjector.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pCBindingSource, "Name", true));
            this.dgvProjector.Location = new System.Drawing.Point(535, 38);
            this.dgvProjector.Name = "dgvProjector";
            this.dgvProjector.ReadOnly = true;
            this.dgvProjector.RowHeadersVisible = false;
            this.dgvProjector.Size = new System.Drawing.Size(193, 354);
            this.dgvProjector.TabIndex = 8;
            // 
            // dgvrPcName
            // 
            this.dgvrPcName.HeaderText = "Name";
            this.dgvrPcName.Name = "dgvrPcName";
            this.dgvrPcName.ReadOnly = true;
            this.dgvrPcName.Width = 150;
            // 
            // dgvrPcStatus
            // 
            this.dgvrPcStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrPcStatus.HeaderText = "Status";
            this.dgvrPcStatus.Name = "dgvrPcStatus";
            this.dgvrPcStatus.ReadOnly = true;
            // 
            // dgvrMonitorName
            // 
            this.dgvrMonitorName.HeaderText = "Name";
            this.dgvrMonitorName.Name = "dgvrMonitorName";
            this.dgvrMonitorName.ReadOnly = true;
            this.dgvrMonitorName.Width = 150;
            // 
            // dgvrMonitorPower
            // 
            this.dgvrMonitorPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrMonitorPower.HeaderText = "Power";
            this.dgvrMonitorPower.Name = "dgvrMonitorPower";
            this.dgvrMonitorPower.ReadOnly = true;
            // 
            // dgvrMonitorInput
            // 
            this.dgvrMonitorInput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrMonitorInput.HeaderText = "Input";
            this.dgvrMonitorInput.Name = "dgvrMonitorInput";
            this.dgvrMonitorInput.ReadOnly = true;
            // 
            // dgvrProjectorName
            // 
            this.dgvrProjectorName.HeaderText = "Name";
            this.dgvrProjectorName.Name = "dgvrProjectorName";
            this.dgvrProjectorName.ReadOnly = true;
            this.dgvrProjectorName.Width = 150;
            // 
            // dgvrProjectorStatus
            // 
            this.dgvrProjectorStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrProjectorStatus.HeaderText = "Status";
            this.dgvrProjectorStatus.Name = "dgvrProjectorStatus";
            this.dgvrProjectorStatus.ReadOnly = true;
            // 
            // pCBindingSource
            // 
            this.pCBindingSource.DataSource = typeof(RoomControl.PC);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 414);
            this.Controls.Add(this.dgvProjector);
            this.Controls.Add(this.dgvMonitor);
            this.Controls.Add(this.dgvPC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Control Devices";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPC;
        private System.Windows.Forms.BindingSource pCBindingSource;
        private System.Windows.Forms.DataGridView dgvMonitor;
        private System.Windows.Forms.DataGridView dgvProjector;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrPcName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrPcStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrMonitorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorPower;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrProjectorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrProjectorStatus;
    }
}

