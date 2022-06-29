using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; 
using System.Windows.Forms;
using System.IO.Ports; 
using System.Threading;
using System.IO;

namespace ITXScaleSerialControl
{
    public partial class ScaleSerialControl: UserControl
    {
        public int fontSizeV=40;
        //public new event EventHandler Click
        //{
        //    add
        //    {
        //        base.Click += value;
        //        foreach (Control control in Controls)
        //        {
        //            control.Click += value;
        //        }
        //    }
        //    remove
        //    {
        //        base.Click -= value;
        //        foreach (Control control in Controls)
        //        {
        //            control.Click -= value;
        //        }
        //    }
        //}

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
            //if (com == null || com=="") return ;
            //var e = new EPSON();
            //using (SerialPrinter printer = new SerialPrinter(portName: /*"COM7"*/ com, baudRate: baud))
            //{
            //    printer.DataAvailable();
            //    printer.Write(
            //      ByteSplicer.Combine(
            //        //e.CenterAlign(),
            //        hasImage ? e.PrintImage(image, true) : e.Print(""),
            //        e.Print(alltext)
            //        ));
            //    Thread.Sleep(500);
            //}
            SerialPort se = new SerialPort();
            se.PortName = com;
            se.BaudRate = 9600;
            se.Parity = Parity.None;
            se.StopBits = StopBits.One;
            if (se.IsOpen)
            {
                se.Close();
            }
            using (se)
            {
                se.Open();
                se.Write(alltext);
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

                    foreach(Control control2 in control.Controls)
                    {
                        control2.DoubleClick += value;
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
        public bool lineread=false;
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



        public string CurrentValue;
        public bool motionDetected;
        public bool isTare;
        public bool isLB;
        public bool cancel=false;

        private Queue<byte> recievedData = new Queue<byte>();

        public ScaleSerialControl()
        {
            InitializeComponent();
            //lbl_currentValue.Font = new Font(lbl_currentValue.Font.FontFamily,100);
            //StartRead();

        }
        public void StartRead()
        {
            bw_serialRead.RunWorkerAsync();
            //System.Windows.Forms.MessageBox.Show(port_1.PortName);
        }
        public void StopRead()
        {

            bw_serialRead.CancelAsync();
           
            
        }
        public string readerT(string current)
        {
            
            return "";
        }

        private void bw_serialRead_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{

            
            if (port_1.IsOpen)
                {
                    port_1.Close();
                }

            //MessageBox.Show("Test");
            try

            { port_1.Open(); }
            catch { }
            
            //MessageBox.Show("Testa");
            while (port_1.IsOpen)
                {
                if (!port_1.IsOpen) { break; }
                int intBuffer;
                intBuffer = port_1.BytesToRead;
                byte[] byteBuffer = new byte[intBuffer];
                //var c = port_1.ReadExisting();
                //var p=port_1.Read(byteBuffer, 0, intBuffer);
                //MessageBox.Show(port_1.PortName);
                //MessageBox.Show(current.Substring(1, current.Length-1));
                //var bytes = Convert.FromBase64CharArray(current);
                //string current="";
                //try
                //{
                //    current = port_1.ReadLine();
                //}
                //catch (System.IO.IOException)
                //{
                //    Console.WriteLine(e.Argument);
                //    Console.WriteLine(e.Result);
                //    Console.WriteLine(e.Cancel) ;
                //}

                var current = "";


                if (lineread)
                {
                    string s = "";
                    try
                    {
                        current = port_1.ReadLine() ;

                        if (current.Length == 0) return;
                        s = current.Substring(1, current.Length -1).Split('L')[0];
                        
                    }
                    catch (System.IO.IOException)
                    {
                        Console.WriteLine(e.Argument);
                        Console.WriteLine(e.Result);
                        Console.WriteLine(e.Cancel);
                    }

                    string i = s.Trim();
                    
                    if (current.Contains("MO"))
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
                    if ((current.Contains("LB"))|| current.Contains("LG"))
                    {
                        //Te units are not in lbs

                        isLB = true;
                    }
                    else
                    {
                        isLB = false;
                        //Good Value
                    }
                    CurrentValue = i;



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
                    if (i.Length == 16 )
                    {
                        if (i.Contains("-"))
                        {
                            string str = i.Substring(1, 7);
                            CurrentValue = (Convert.ToInt32(str) * (-1)).ToString();
                        }
                        else
                        {
                            CurrentValue = i.Substring(0, 7).Trim();
                        }
                        if (i.Contains("MO"))
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
                        if (i.Contains("LB")|| i.Contains("L"))
                        {
                            //Te units are not in lbs

                            isLB = true;
                        }
                        else
                        {
                            isLB = false;

                            if (i.Contains("-"))
                            {
                                string str = CurrentValue.Substring(1, 7);
                                CurrentValue = (Convert.ToInt32(str) * (-1)).ToString();
                            }
                            //Good Value
                        }
                        //foreach (string j in current.Split('\n')) 
                        //{
                        //    //current.Substring(1,current.Length-1).Trim('\'').Replace("\\r","^").Split('^')
                        //    string i = j;
                        //        //MessageBox.Show(i);



                    }
                }
                    //}
                    Thread.Sleep(10);
                bw_serialRead.ReportProgress(0, true);
                }
            //}
            //catch (Exception ee)
            //{
            //    port_1.Close();
            //    MessageBox.Show(ee.Message+ee.Source);
            //    //bw_serialRead_DoWork(sender, e);
            //}

        }
        delegate void SetTextCallback(string text,bool v);

        private void SetText(string text,bool v)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbl_currentValue.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text,v });
            }
            else
            {
                this.lbl_currentValue.Text = Convert.ToInt32( text).ToString("N0");
                ChangeFore(v);
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
            SetText(CurrentValue,motionDetected);
            if (motionDetected)
            {
                SetTextM(lblm);
            }
            else
            {
                SetTextM("");
            }
        }
       
    }
}
