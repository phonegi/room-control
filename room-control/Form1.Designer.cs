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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPC = new System.Windows.Forms.DataGridView();
            this.dgvMonitor = new System.Windows.Forms.DataGridView();
            this.dgvProjector = new System.Windows.Forms.DataGridView();
            this.cmdMonitorInputPc = new System.Windows.Forms.Button();
            this.cmdMonitorInputBroadcast = new System.Windows.Forms.Button();
            this.cmdProjectorOff = new System.Windows.Forms.Button();
            this.cmdProjectorOn = new System.Windows.Forms.Button();
            this.cmdMonitorOff = new System.Windows.Forms.Button();
            this.cmdMonitorOn = new System.Windows.Forms.Button();
            this.cmdPcOff = new System.Windows.Forms.Button();
            this.cmdPcOn = new System.Windows.Forms.Button();
            this.dgvrPcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrPcPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrMonitorPower = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrMonitorInput = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvrProjectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvrProjectorPower = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjector)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PCs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monitors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(841, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Projectors";
            // 
            // dgvPC
            // 
            this.dgvPC.AllowUserToAddRows = false;
            this.dgvPC.AllowUserToDeleteRows = false;
            this.dgvPC.AllowUserToResizeRows = false;
            this.dgvPC.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrPcName,
            this.dgvrPcPower});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPC.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPC.Location = new System.Drawing.Point(17, 47);
            this.dgvPC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPC.Name = "dgvPC";
            this.dgvPC.ReadOnly = true;
            this.dgvPC.RowHeadersVisible = false;
            this.dgvPC.Size = new System.Drawing.Size(257, 407);
            this.dgvPC.TabIndex = 6;
            this.dgvPC.TabStop = false;
            // 
            // dgvMonitor
            // 
            this.dgvMonitor.AllowUserToAddRows = false;
            this.dgvMonitor.AllowUserToDeleteRows = false;
            this.dgvMonitor.AllowUserToResizeRows = false;
            this.dgvMonitor.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrMonitorName,
            this.dgvrMonitorPower,
            this.dgvrMonitorInput});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonitor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonitor.Location = new System.Drawing.Point(327, 47);
            this.dgvMonitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.ReadOnly = true;
            this.dgvMonitor.RowHeadersVisible = false;
            this.dgvMonitor.Size = new System.Drawing.Size(419, 407);
            this.dgvMonitor.TabIndex = 7;
            // 
            // dgvProjector
            // 
            this.dgvProjector.AllowUserToAddRows = false;
            this.dgvProjector.AllowUserToDeleteRows = false;
            this.dgvProjector.AllowUserToResizeRows = false;
            this.dgvProjector.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvProjector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvrProjectorName,
            this.dgvrProjectorPower});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProjector.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProjector.Location = new System.Drawing.Point(845, 47);
            this.dgvProjector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProjector.Name = "dgvProjector";
            this.dgvProjector.ReadOnly = true;
            this.dgvProjector.RowHeadersVisible = false;
            this.dgvProjector.Size = new System.Drawing.Size(297, 407);
            this.dgvProjector.TabIndex = 8;
            // 
            // cmdMonitorInputPc
            // 
            this.cmdMonitorInputPc.FlatAppearance.BorderSize = 0;
            this.cmdMonitorInputPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorInputPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorInputPc.Image = global::RoomControl.Properties.Resources.laptop_22x22;
            this.cmdMonitorInputPc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorInputPc.Location = new System.Drawing.Point(520, 506);
            this.cmdMonitorInputPc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMonitorInputPc.Name = "cmdMonitorInputPc";
            this.cmdMonitorInputPc.Size = new System.Drawing.Size(225, 37);
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
            this.cmdMonitorInputBroadcast.Location = new System.Drawing.Point(520, 462);
            this.cmdMonitorInputBroadcast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMonitorInputBroadcast.Name = "cmdMonitorInputBroadcast";
            this.cmdMonitorInputBroadcast.Size = new System.Drawing.Size(225, 37);
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
            this.cmdProjectorOff.Location = new System.Drawing.Point(845, 506);
            this.cmdProjectorOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdProjectorOff.Name = "cmdProjectorOff";
            this.cmdProjectorOff.Size = new System.Drawing.Size(156, 37);
            this.cmdProjectorOff.TabIndex = 14;
            this.cmdProjectorOff.Text = "Power OFF";
            this.cmdProjectorOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProjectorOff.UseVisualStyleBackColor = true;
            this.cmdProjectorOff.Click += new System.EventHandler(this.cmdProjectorOff_Click);
            // 
            // cmdProjectorOn
            // 
            this.cmdProjectorOn.FlatAppearance.BorderSize = 0;
            this.cmdProjectorOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdProjectorOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProjectorOn.Image = global::RoomControl.Properties.Resources.power_button_on_22x22;
            this.cmdProjectorOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProjectorOn.Location = new System.Drawing.Point(845, 462);
            this.cmdProjectorOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdProjectorOn.Name = "cmdProjectorOn";
            this.cmdProjectorOn.Size = new System.Drawing.Size(147, 37);
            this.cmdProjectorOn.TabIndex = 13;
            this.cmdProjectorOn.Text = "Power ON";
            this.cmdProjectorOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProjectorOn.UseVisualStyleBackColor = true;
            this.cmdProjectorOn.Click += new System.EventHandler(this.cmdProjectorOn_Click);
            // 
            // cmdMonitorOff
            // 
            this.cmdMonitorOff.FlatAppearance.BorderSize = 0;
            this.cmdMonitorOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMonitorOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonitorOff.Image = global::RoomControl.Properties.Resources.power_button_off_22x22;
            this.cmdMonitorOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMonitorOff.Location = new System.Drawing.Point(327, 506);
            this.cmdMonitorOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMonitorOff.Name = "cmdMonitorOff";
            this.cmdMonitorOff.Size = new System.Drawing.Size(156, 37);
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
            this.cmdMonitorOn.Location = new System.Drawing.Point(327, 462);
            this.cmdMonitorOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMonitorOn.Name = "cmdMonitorOn";
            this.cmdMonitorOn.Size = new System.Drawing.Size(147, 37);
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
            this.cmdPcOff.Location = new System.Drawing.Point(17, 506);
            this.cmdPcOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPcOff.Name = "cmdPcOff";
            this.cmdPcOff.Size = new System.Drawing.Size(156, 37);
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
            this.cmdPcOn.Location = new System.Drawing.Point(17, 462);
            this.cmdPcOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPcOn.Name = "cmdPcOn";
            this.cmdPcOn.Size = new System.Drawing.Size(147, 37);
            this.cmdPcOn.TabIndex = 9;
            this.cmdPcOn.Text = "Power ON";
            this.cmdPcOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPcOn.UseVisualStyleBackColor = true;
            this.cmdPcOn.Click += new System.EventHandler(this.cmdPcOn_Click);
            // 
            // dgvrPcName
            // 
            this.dgvrPcName.HeaderText = "Name";
            this.dgvrPcName.Name = "dgvrPcName";
            this.dgvrPcName.ReadOnly = true;
            this.dgvrPcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // dgvrMonitorName
            // 
            this.dgvrMonitorName.HeaderText = "Name";
            this.dgvrMonitorName.Name = "dgvrMonitorName";
            this.dgvrMonitorName.ReadOnly = true;
            this.dgvrMonitorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // dgvrProjectorName
            // 
            this.dgvrProjectorName.HeaderText = "Name";
            this.dgvrProjectorName.Name = "dgvrProjectorName";
            this.dgvrProjectorName.ReadOnly = true;
            this.dgvrProjectorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvrProjectorName.Width = 180;
            // 
            // dgvrProjectorPower
            // 
            this.dgvrProjectorPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvrProjectorPower.HeaderText = "Power";
            this.dgvrProjectorPower.Name = "dgvrProjectorPower";
            this.dgvrProjectorPower.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1173, 559);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Control Devices";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrMonitorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorPower;
        private System.Windows.Forms.DataGridViewImageColumn dgvrMonitorInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvrProjectorName;
        private System.Windows.Forms.DataGridViewImageColumn dgvrProjectorPower;
    }
}

