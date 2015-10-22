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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPC = new System.Windows.Forms.DataGridView();
            this.dgvMonitor = new System.Windows.Forms.DataGridView();
            this.dgvProjector = new System.Windows.Forms.DataGridView();
            this.dgvrPcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrPcPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrProjectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrProjectorPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrMonitorPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorInput = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmdMonitorInputPc = new System.Windows.Forms.Button();
            this.cmdMonitorInputBroadcast = new System.Windows.Forms.Button();
            this.cmdProjectorOff = new System.Windows.Forms.Button();
            this.cmdProjectorOn = new System.Windows.Forms.Button();
            this.cmdMonitorOff = new System.Windows.Forms.Button();
            this.cmdMonitorOn = new System.Windows.Forms.Button();
            this.cmdPcOff = new System.Windows.Forms.Button();
            this.cmdPcOn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjector)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "PCs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monitors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
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
            this.dgvrPcPower});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPC.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPC.Location = new System.Drawing.Point(13, 38);
            this.dgvPC.Name = "dgvPC";
            this.dgvPC.ReadOnly = true;
            this.dgvPC.RowHeadersVisible = false;
            this.dgvPC.Size = new System.Drawing.Size(193, 331);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonitor.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMonitor.Location = new System.Drawing.Point(245, 38);
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.ReadOnly = true;
            this.dgvMonitor.RowHeadersVisible = false;
            this.dgvMonitor.Size = new System.Drawing.Size(314, 331);
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
            this.dgvrProjectorPower});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProjector.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProjector.Location = new System.Drawing.Point(634, 38);
            this.dgvProjector.Name = "dgvProjector";
            this.dgvProjector.ReadOnly = true;
            this.dgvProjector.RowHeadersVisible = false;
            this.dgvProjector.Size = new System.Drawing.Size(223, 331);
            this.dgvProjector.TabIndex = 8;
            // 
            // dgvrPcName
            // 
            this.dgvrPcName.HeaderText = "Name";
            this.dgvrPcName.Name = "dgvrPcName";
            this.dgvrPcName.ReadOnly = true;
            this.dgvrPcName.Width = 150;
            // 
            // dgvrPcPower
            // 
            this.dgvrPcPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrPcPower.HeaderText = "Power";
            this.dgvrPcPower.Name = "dgvrPcPower";
            this.dgvrPcPower.ReadOnly = true;
            this.dgvrPcPower.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvrProjectorName
            // 
            this.dgvrProjectorName.HeaderText = "Name";
            this.dgvrProjectorName.Name = "dgvrProjectorName";
            this.dgvrProjectorName.ReadOnly = true;
            this.dgvrProjectorName.Width = 180;
            // 
            // dgvrProjectorPower
            // 
            this.dgvrProjectorPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrProjectorPower.HeaderText = "Power";
            this.dgvrProjectorPower.Name = "dgvrProjectorPower";
            this.dgvrProjectorPower.ReadOnly = true;
            // 
            // dgvrMonitorName
            // 
            this.dgvrMonitorName.HeaderText = "Name";
            this.dgvrMonitorName.Name = "dgvrMonitorName";
            this.dgvrMonitorName.ReadOnly = true;
            this.dgvrMonitorName.Width = 215;
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
            // cmdMonitorInputPc
            // 
            this.cmdMonitorInputPc.FlatAppearance.BorderSize = 0;
            this.cmdMonitorInputPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorInputPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorInputPc.Image = global::RoomControl.Properties.Resources.laptop_22x22;
            this.cmdMonitorInputPc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorInputPc.Location = new System.Drawing.Point(390, 411);
            this.cmdMonitorInputPc.Name = "cmdMonitorInputPc";
            this.cmdMonitorInputPc.Size = new System.Drawing.Size(169, 30);
            this.cmdMonitorInputPc.TabIndex = 16;
            this.cmdMonitorInputPc.Text = "Display Local PC";
            this.cmdMonitorInputPc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMonitorInputPc.UseVisualStyleBackColor = true;
            this.cmdMonitorInputPc.Click += new System.EventHandler(this.cmdMonitorInputPc_Click);
            // 
            // cmdMonitorInputBroadcast
            // 
            this.cmdMonitorInputBroadcast.FlatAppearance.BorderSize = 0;
            this.cmdMonitorInputBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorInputBroadcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorInputBroadcast.Image = global::RoomControl.Properties.Resources.broadcast_22x22;
            this.cmdMonitorInputBroadcast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorInputBroadcast.Location = new System.Drawing.Point(390, 375);
            this.cmdMonitorInputBroadcast.Name = "cmdMonitorInputBroadcast";
            this.cmdMonitorInputBroadcast.Size = new System.Drawing.Size(169, 30);
            this.cmdMonitorInputBroadcast.TabIndex = 15;
            this.cmdMonitorInputBroadcast.Text = "Display Broadcast";
            this.cmdMonitorInputBroadcast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMonitorInputBroadcast.UseVisualStyleBackColor = true;
            this.cmdMonitorInputBroadcast.Click += new System.EventHandler(this.cmdMonitorInputBroadcast_Click);
            // 
            // cmdProjectorOff
            // 
            this.cmdProjectorOff.FlatAppearance.BorderSize = 0;
            this.cmdProjectorOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdProjectorOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProjectorOff.Image = global::RoomControl.Properties.Resources.power_button_off_22x22;
            this.cmdProjectorOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProjectorOff.Location = new System.Drawing.Point(634, 411);
            this.cmdProjectorOff.Name = "cmdProjectorOff";
            this.cmdProjectorOff.Size = new System.Drawing.Size(117, 30);
            this.cmdProjectorOff.TabIndex = 14;
            this.cmdProjectorOff.Text = "Power OFF";
            this.cmdProjectorOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProjectorOff.UseVisualStyleBackColor = true;
            // 
            // cmdProjectorOn
            // 
            this.cmdProjectorOn.FlatAppearance.BorderSize = 0;
            this.cmdProjectorOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdProjectorOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProjectorOn.Image = global::RoomControl.Properties.Resources.power_button_on_22x22;
            this.cmdProjectorOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProjectorOn.Location = new System.Drawing.Point(634, 375);
            this.cmdProjectorOn.Name = "cmdProjectorOn";
            this.cmdProjectorOn.Size = new System.Drawing.Size(110, 30);
            this.cmdProjectorOn.TabIndex = 13;
            this.cmdProjectorOn.Text = "Power ON";
            this.cmdProjectorOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProjectorOn.UseVisualStyleBackColor = true;
            // 
            // cmdMonitorOff
            // 
            this.cmdMonitorOff.FlatAppearance.BorderSize = 0;
            this.cmdMonitorOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorOff.Image = global::RoomControl.Properties.Resources.power_button_off_22x22;
            this.cmdMonitorOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorOff.Location = new System.Drawing.Point(245, 411);
            this.cmdMonitorOff.Name = "cmdMonitorOff";
            this.cmdMonitorOff.Size = new System.Drawing.Size(117, 30);
            this.cmdMonitorOff.TabIndex = 12;
            this.cmdMonitorOff.Text = "Power OFF";
            this.cmdMonitorOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMonitorOff.UseVisualStyleBackColor = true;
            this.cmdMonitorOff.Click += new System.EventHandler(this.cmdMonitorOff_Click);
            // 
            // cmdMonitorOn
            // 
            this.cmdMonitorOn.FlatAppearance.BorderSize = 0;
            this.cmdMonitorOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorOn.Image = global::RoomControl.Properties.Resources.power_button_on_22x22;
            this.cmdMonitorOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorOn.Location = new System.Drawing.Point(245, 375);
            this.cmdMonitorOn.Name = "cmdMonitorOn";
            this.cmdMonitorOn.Size = new System.Drawing.Size(110, 30);
            this.cmdMonitorOn.TabIndex = 11;
            this.cmdMonitorOn.Text = "Power ON";
            this.cmdMonitorOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMonitorOn.UseVisualStyleBackColor = true;
            this.cmdMonitorOn.Click += new System.EventHandler(this.cmdMonitorOn_Click);
            // 
            // cmdPcOff
            // 
            this.cmdPcOff.FlatAppearance.BorderSize = 0;
            this.cmdPcOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPcOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPcOff.Image = global::RoomControl.Properties.Resources.power_button_off_22x22;
            this.cmdPcOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPcOff.Location = new System.Drawing.Point(13, 411);
            this.cmdPcOff.Name = "cmdPcOff";
            this.cmdPcOff.Size = new System.Drawing.Size(117, 30);
            this.cmdPcOff.TabIndex = 10;
            this.cmdPcOff.Text = "Power OFF";
            this.cmdPcOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPcOff.UseVisualStyleBackColor = true;
            this.cmdPcOff.Click += new System.EventHandler(this.cmdPcOff_Click);
            // 
            // cmdPcOn
            // 
            this.cmdPcOn.FlatAppearance.BorderSize = 0;
            this.cmdPcOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPcOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPcOn.Image = global::RoomControl.Properties.Resources.power_button_on_22x22;
            this.cmdPcOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPcOn.Location = new System.Drawing.Point(13, 375);
            this.cmdPcOn.Name = "cmdPcOn";
            this.cmdPcOn.Size = new System.Drawing.Size(110, 30);
            this.cmdPcOn.TabIndex = 9;
            this.cmdPcOn.Text = "Power ON";
            this.cmdPcOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPcOn.UseVisualStyleBackColor = true;
            this.cmdPcOn.Click += new System.EventHandler(this.cmdPcOn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(880, 454);
            this.Controls.Add(this.cmdMonitorInputPc);
            this.Controls.Add(this.cmdMonitorInputBroadcast);
            this.Controls.Add(this.cmdProjectorOff);
            this.Controls.Add(this.cmdProjectorOn);
            this.Controls.Add(this.cmdMonitorOff);
            this.Controls.Add(this.cmdMonitorOn);
            this.Controls.Add(this.cmdPcOff);
            this.Controls.Add(this.cmdPcOn);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPC;
        private System.Windows.Forms.DataGridView dgvMonitor;
        private System.Windows.Forms.DataGridView dgvProjector;
        private System.Windows.Forms.Button cmdPcOn;
        private System.Windows.Forms.Button cmdPcOff;
        private System.Windows.Forms.Button cmdMonitorOn;
        private System.Windows.Forms.Button cmdMonitorOff;
        private System.Windows.Forms.Button cmdProjectorOff;
        private System.Windows.Forms.Button cmdProjectorOn;
        private System.Windows.Forms.Button cmdMonitorInputPc;
        private System.Windows.Forms.Button cmdMonitorInputBroadcast;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrPcName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrPcPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrProjectorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrProjectorPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrMonitorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorPower;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorInput;
    }
}

