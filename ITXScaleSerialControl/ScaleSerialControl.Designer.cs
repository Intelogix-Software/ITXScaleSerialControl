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
            this.lbl_currentValue = new DevExpress.XtraEditors.LabelControl();
            this.bw_serialRead = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbl_currentValue);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(497, 98);
            this.panelControl1.TabIndex = 0;
            // 
            // lbl_currentValue
            // 
            this.lbl_currentValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_currentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentValue.Appearance.Options.UseFont = true;
            this.lbl_currentValue.Location = new System.Drawing.Point(62, 16);
            this.lbl_currentValue.Name = "lbl_currentValue";
            this.lbl_currentValue.Size = new System.Drawing.Size(371, 77);
            this.lbl_currentValue.TabIndex = 0;
            this.lbl_currentValue.Text = "labelControl1";
            // 
            // bw_serialRead
            // 
            this.bw_serialRead.WorkerReportsProgress = true;
            this.bw_serialRead.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_serialRead_DoWork);
            this.bw_serialRead.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_serialRead_ProgressChanged);
            this.bw_serialRead.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_serialRead_RunWorkerCompleted);
            // 
            // ScaleSerialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ScaleSerialControl";
            this.Size = new System.Drawing.Size(497, 98);
            this.Load += new System.EventHandler(this.ScaleSerialControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort port_1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_currentValue;
        private System.ComponentModel.BackgroundWorker bw_serialRead;
    }
}
