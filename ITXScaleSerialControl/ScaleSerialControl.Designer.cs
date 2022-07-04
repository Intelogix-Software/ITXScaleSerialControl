namespace ITXScaleSerialControl
{
    partial class ScaleSerialControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.port_1 = new System.IO.Ports.SerialPort(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_currentValue = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_motion = new DevExpress.XtraEditors.LabelControl();
            this.bw_serialRead = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_1
            // 
            this.port_1.PortName = "COM2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(421, 98);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_currentValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 94);
            this.panel1.TabIndex = 2;
            // 
            // lbl_currentValue
            // 
            this.lbl_currentValue.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentValue.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lbl_currentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentValue.Appearance.Options.UseBackColor = true;
            this.lbl_currentValue.Appearance.Options.UseFont = true;
            this.lbl_currentValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_currentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_currentValue.Enabled = false;
            this.lbl_currentValue.Location = new System.Drawing.Point(0, 0);
            this.lbl_currentValue.Name = "lbl_currentValue";
            this.lbl_currentValue.Size = new System.Drawing.Size(242, 94);
            this.lbl_currentValue.TabIndex = 0;
            this.lbl_currentValue.Text = "SerialValue";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_motion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(244, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 94);
            this.panel2.TabIndex = 4;
            // 
            // lbl_motion
            // 
            this.lbl_motion.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbl_motion.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motion.Appearance.Options.UseBackColor = true;
            this.lbl_motion.Appearance.Options.UseFont = true;
            this.lbl_motion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_motion.Enabled = false;
            this.lbl_motion.ImageOptions.Image = global::ITXScaleSerialControl.Properties.Resources.merge_32x32;
            this.lbl_motion.Location = new System.Drawing.Point(0, 0);
            this.lbl_motion.Name = "lbl_motion";
            this.lbl_motion.Size = new System.Drawing.Size(32, 32);
            this.lbl_motion.TabIndex = 1;
            // 
            // bw_serialRead
            // 
            this.bw_serialRead.WorkerReportsProgress = true;
            this.bw_serialRead.WorkerSupportsCancellation = true;
            this.bw_serialRead.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_serialRead_DoWork);
            this.bw_serialRead.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_serialRead_ProgressChanged);
            // 
            // ScaleSerialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ScaleSerialControl";
            this.Size = new System.Drawing.Size(421, 98);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.BackgroundWorker bw_serialRead;
        private DevExpress.XtraEditors.LabelControl lbl_motion;
        public System.IO.Ports.SerialPort port_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.LabelControl lbl_currentValue;
        public System.Windows.Forms.Panel panel2;
    }
}
