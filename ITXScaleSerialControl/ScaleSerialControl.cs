using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ITXScaleSerialControl
{
    public partial class ScaleSerialControl: UserControl
    {
        public string SerialPortCOMName
        {
            get { return port_1.PortName; }
            set { port_1.PortName = value; }
        }
        public int SerialPortBaud
        {
            get { return port_1.BaudRate; }
            set { port_1.BaudRate = value; }
        }
        public string CurrentValue;
        
        public ScaleSerialControl()
        {
            InitializeComponent();
            
        }
        public void StartRead()
        {
            bw_serialRead.RunWorkerAsync();
        }
        private void bw_serialRead_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                port_1.Open();
                while (port_1.IsOpen)
                {
                    int intBuffer;
                    intBuffer = port_1.BytesToRead;
                    byte[] byteBuffer = new byte[intBuffer];
                    port_1.Read(byteBuffer, 0, intBuffer);
                    CurrentValue = port_1.ReadLine();
                    bw_serialRead.ReportProgress(0, true);


                }
            }
            catch (Exception)
            {
                port_1.Close();
            }
            
        }

        private void bw_serialRead_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbl_currentValue.Text = CurrentValue;
        }

        private void ScaleSerialControl_Load(object sender, EventArgs e)
        {
            //bw_serialRead.RunWorkerAsync();
        }

        private void bw_serialRead_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                bw_serialRead.RunWorkerAsync();
            }catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
