using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace ITXScaleSerialControl
{
    public partial class ScaleSerialControl : UserControl
    {
        public int fontSizeV = 40;

        public bool hasImage { get; set; }
        private readonly MemoryStream _ms;
        public static string com { get; set; }
        public static Int16 baud { get; set; }

        public void settings(bool HasImage, string printerCom, Int16 baudrate)
        {

            hasImage = HasImage;
            com = printerCom;
            baud = baudrate;
        }
        public void print(string alltext, byte[] image)
        {
            SerialPort se = new SerialPort();
            se.PortName = com;
            se.BaudRate = 9600;
            se.Parity = Parity.None;
            se.StopBits = StopBits.One;
            if (se.IsOpen)
            {
                se.DiscardInBuffer();
                se.DiscardOutBuffer();  
                se.Close();
            }
            using (se)
            {
                se.Open();
                se.Write(alltext);
                se.DiscardInBuffer();
                se.DiscardOutBuffer();
                se.Close();
            }

        }
        public event EventHandler DoubleClick2
        {
            add
            {
                base.DoubleClick += value;
                foreach (Control control in this.Controls)
                {

                    control.DoubleClick += value;

                    foreach (Control control2 in control.Controls)
                    {
                        control2.DoubleClick += value;
                        foreach (Control control3 in control2.Controls)
                        {
                            control3.DoubleClick += value;
                        }
                    }
                }
            }
            remove
            {
                base.DoubleClick -= value;
                foreach (Control control in Controls)
                {
                    control.DoubleClick -= value;
                    foreach (Control control2 in control.Controls)
                    {
                        control2.DoubleClick -= value;
                        foreach (Control control3 in control2.Controls)
                        {
                            control3.DoubleClick -= value;
                        }
                    }
                }
            }
        }
        private void Control_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
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
        public bool lineread = false;
        public bool lread
        {
            get { return lineread; }
            set { lineread = value; }
        }
        public Font lblFont
        {
            get { return lbl_currentValue.Font; }
            set { lbl_currentValue.Font = value; }
        }
        public Color Fore
        {
            get { return lbl_currentValue.ForeColor; }
            set { lbl_currentValue.ForeColor = value; }
        }
        public Image lblMotionImage
        {
            get { return lbl_motion.ImageOptions.Image; }
            set { lbl_motion.ImageOptions.Image = value; }
        }
        public Font lblMotion
        {
            get { return lbl_motion.Font; }
            set { lbl_motion.Font = value; }
        }
        private string lblm;
        public string lblMotionText
        {
            get { return lblm; }
            set { lblm = value; }
        }
        public Color ForeMotion
        {
            get { return lbl_motion.ForeColor; }
            set { lbl_motion.ForeColor = value; }
        }


        public void SetPort(string PortName)
        {
            if (port_1 == null) { port_1 = new SerialPort();}
            SerialPortCOMName = PortName;
        }

        public string CurrentValue;
        public bool motionDetected;
        public bool isTare;
        public bool isLB;
        public bool cancel = false;

        private Queue<byte> recievedData = new Queue<byte>();

        public ScaleSerialControl()
        {
            InitializeComponent();
        }
        public void StartRead()
        {
            bw_serialRead.RunWorkerAsync();

        }
        public void StopRead()
        {
            if (port_1.IsOpen)
            {
                port_1.DiscardInBuffer();
                port_1.DiscardOutBuffer();
                port_1.Close();
            }
        }
        public string readerT(string current)
        {

            return "";
        }
        public void restartPort()
        {
            if (port_1 == null) {port_1 = new SerialPort();}    

            if (port_1.IsOpen)
            {
                port_1.DiscardInBuffer();
                port_1.DiscardOutBuffer();
                port_1.Close();
            }
            Thread.Sleep(500);
            try { port_1.Open(); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private void bw_serialRead_DoWork(object sender, DoWorkEventArgs e)
        {
            if (port_1.IsOpen)
            {
                port_1.DiscardInBuffer();
                port_1.DiscardOutBuffer();
                port_1.Close();
            }

            try

            { port_1.Open(); }
            catch { }

            while (port_1.IsOpen)
            {
                if (!port_1.IsOpen) { break; }
                int intBuffer;
                intBuffer = port_1.BytesToRead;
                byte[] byteBuffer = new byte[intBuffer];

                var current = "";

                if (lineread)
                {
                    string s = "";
                    try
                    {
                        current = port_1.ReadLine();

                        if (current.Length == 0) return;
                        s = current.Substring(1, current.Length - 1).Split('L')[0];

                    }
                    catch (System.IO.IOException)
                    {
                        Console.WriteLine(e.Argument);
                        Console.WriteLine(e.Result);
                        Console.WriteLine(e.Cancel);
                        return;
                    }

                    string i = s.Trim();


                    if (current.Contains("M") || current.Contains("MO"))
                    {
                        //MOtion detected

                        motionDetected = true;
                    }
                    else
                    {
                        motionDetected = false;

                    }
                    if (current.Contains("CZ"))
                    {
                        //te value is 0 or on tare
                        isTare = true;
                    }
                    else
                    {
                        isTare = false;
                    }
                    if ((current.Contains("LB")) || current.Contains("LG"))
                    {
                        //Te units are not in lbs

                        isLB = true;
                    }
                    else
                    {
                        isLB = false;
                        //Good Value
                    }
                    CurrentValue = Regex.Match(i.Replace(" ", ""), @"\d+").Value;
                }
                else
                {
                    try
                    {
                        current = port_1.ReadExisting();
                    }
                    catch (System.IO.IOException)
                    {
                        Console.WriteLine(e.Argument);
                        Console.WriteLine(e.Result);
                        Console.WriteLine(e.Cancel);

                    }

                    string i = current;
                    if (i.Length == 16)
                    {
                        if (i.Contains("-"))
                        {
                            //string str = i.Substring(1, 7);
                            CurrentValue = Regex.Match(i.Replace(" ", ""), @"\d+").Value;
                        }
                        else
                        {
                            //CurrentValue = i.Substring(0, 7).Trim();
                            CurrentValue = Regex.Match(i.Replace(" ", ""), @"\d+").Value;
                        }
                        if (i.Contains("M"))
                        {
                            //MOtion detected

                            motionDetected = true;
                        }
                        else
                        {
                            motionDetected = false;

                        }
                        if (i.Contains("CZ"))
                        {
                            //te value is 0 or on tare
                            isTare = true;
                        }
                        else
                        {
                            isTare = false;
                        }
                        if (i.Contains("LB") || i.Contains("L"))
                        {
                            //Te units are not in lbs

                            isLB = true;
                        }
                        else
                        {
                            isLB = false;

                            if (i.Contains("-"))
                            {
                                //string str = CurrentValue.Substring(1, 7);
                                CurrentValue = "-" + Regex.Match(i.Replace(" ", ""), @"\d+").Value;
                            }
                            //Good Value
                        }
                    }
                }
                //}
                Thread.Sleep(10);
                bw_serialRead.ReportProgress(0, true);

            }
        }
        delegate void SetTextCallback(string text, bool v);

        private void SetText(string text, bool v)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                if (this.lbl_currentValue.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text, v });
                }
                else
                {
                    this.lbl_currentValue.Text = Convert.ToInt32(text).ToString("N0", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch
            {

            }
        }
        private void SetTextM(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbl_motion.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbl_motion.Text = text;
            }
        }
        public void ChangeFore(bool v)
        {
            if (v)
            {
                this.Fore = Color.Green;
            }
            else
            {
                this.Fore = Color.Black;
            }
        }

        private void bw_serialRead_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetText(CurrentValue, motionDetected);
            if (motionDetected)
            {
                SetTextM(lblm);
            }
            else
            {
                SetTextM("");
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ScaleSerialControl_Load(object sender, EventArgs e)
        {

        }
    }
}
