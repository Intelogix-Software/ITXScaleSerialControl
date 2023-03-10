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
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.lbl_currentValue = new DevExpress.XtraEditors.LabelControl();
            this.lbl_motion = new DevExpress.XtraEditors.LabelControl();
            this.bw_serialRead = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_1
            // 
            this.port_1.PortName = "COM2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.stackPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(318, 98);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // stackPanel1
            // 
            this.stackPanel1.Controls.Add(this.lbl_currentValue);
            this.stackPanel1.Controls.Add(this.lbl_motion);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.Location = new System.Drawing.Point(2, 2);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(314, 94);
            this.stackPanel1.TabIndex = 2;
            // 
            // lbl_currentValue
            // 
            this.lbl_currentValue.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentValue.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lbl_currentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentValue.Appearance.Options.UseBackColor = true;
            this.lbl_currentValue.Appearance.Options.UseFont = true;
            this.lbl_currentValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_currentValue.Enabled = false;
            this.lbl_currentValue.Location = new System.Drawing.Point(3, 2);
            this.lbl_currentValue.MaximumSize = new System.Drawing.Size(277, 90);
            this.lbl_currentValue.Name = "lbl_currentValue";
            this.lbl_currentValue.Size = new System.Drawing.Size(194, 90);
            this.lbl_currentValue.TabIndex = 0;
            this.lbl_currentValue.Text = "No scale";
            // 
            // lbl_motion
            // 
            this.lbl_motion.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbl_motion.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motion.Appearance.Options.UseBackColor = true;
            this.lbl_motion.Appearance.Options.UseFont = true;
            this.lbl_motion.Enabled = false;
            this.lbl_motion.ImageOptions.Image = global::ITXScaleSerialControl.Properties.Resources.merge_32x32;
            this.lbl_motion.Location = new System.Drawing.Point(203, 31);
            this.lbl_motion.Name = "lbl_motion";
            this.lbl_motion.Size = new System.Drawing.Size(32, 32);
            this.lbl_motion.TabIndex = 1;
            this.lbl_motion.Text = "---";
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
            this.Size = new System.Drawing.Size(318, 98);
            this.Load += new System.EventHandler(this.ScaleSerialControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.stackPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.BackgroundWorker bw_serialRead;
        public System.IO.Ports.SerialPort port_1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lbl_motion;
        public DevExpress.XtraEditors.LabelControl lbl_currentValue;
    }
}
