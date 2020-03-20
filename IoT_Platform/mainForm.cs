using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Firmware_Update_V1._0
{
    public interface IView
    {
        void SetController(IController controller);
        //Open serial port event
        void OpenComEvent(Object sender, SerialPortEventArgs e);
        //Close serial port event
        void CloseComEvent(Object sender, SerialPortEventArgs e);
        //Serial port receive data event
        void ComReceiveDataEvent(Object sender, SerialPortEventArgs e);
    }
    public partial class Form1 : Form, IView
    {
        private Form3 f3;
        private IController controller;
        public static SerialPort serialPort1 = new SerialPort();

        public static byte FirmwareVersionOld = 0x00;
        public static byte[] DeviceNumber = new byte[2];
        public static byte[] PDNumber = new byte[2];

        public static byte TerminalType = 0xFF;
        public static byte TransmissionWay = 0x00;
        public static byte[] DEVEUI = new byte[2];
        public static byte SendPeriod;

        public static byte[] RecBytes = new byte[32];
        //int RecNum = 0;

        int TimerMScounter = 0;//计时器变量

         public Form1()
        {
            InitializeComponent();
        }

         public void SetController(IController controller)
         {
             this.controller = controller;
         }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.baudRateCbx.SelectedIndex = 3;//波特率默认“115200”
            //this.parityCbx.SelectedIndex = 0;//校验位默认“None”
            //this.dataBitsCbx.SelectedIndex = 3;//数据位默认“8”
            //this.stopBitsCbx.SelectedIndex = 0;//停止位默认“1”
            //this.handshakingcbx.SelectedIndex = 0;//流控位默认“0”
            barButtonItem9.Enabled = false;
        }

        private void SearchAndAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)//扫描代码
        {                                                               //将可用端口号添加到ComboBox
            string Buffer;                                              //缓存
            MyBox.Items.Clear();                                        //清空ComboBox内容
            for (int i = 1; i < 60; i++)                                //循环
            {
                try                                                     //核心原理是依靠try和catch完成遍历
                {
                    Buffer = "COM" + i.ToString();
                    MyPort.PortName = Buffer;
                    MyPort.Open();                                      //如果失败，后面的代码不会执行

                    MyBox.Items.Add(Buffer);                            //打开成功，添加至下拉列表
                    MyPort.Close();                                     //关闭
                }
                catch
                { }
            }
        }

        public void scan_combox(ComboBox MyBox)
        {
            SearchAndAddSerialToComboBox(serialPort1, MyBox);//调用扫描代码
        }


        public void OpenUSB_Port(string portName, String baudRate,
            string dataBits, string stopBits, string parity, string handshake)
        {
            try
            {
                controller.OpenSerialPort(portName, baudRate,
                    dataBits, stopBits, parity,            //dataBitsCbx.Text, stopBitsCbx.Text, parityCbx.Text,
                    handshake);

                barButtonItem9.Enabled = false;
            }
            catch
            {
                MessageBox.Show("串口连接失败", "错误");
            }
        }

        public void CloseUSB_Port()
        {
            controller.CloseSerialPort();
            barButtonItem9.Enabled = false;
        }

        public void OpenComEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(OpenComEvent), sender, e);
                return;
            }

            if (e.isOpend)  //Open successfully
            {
                try
                {
                    timer1.Enabled = false;//关闭定时器
                    //baudRateCbx.Enabled = true;//“波特率”可选
                    //parityCbx.Enabled = true;//“校验位”可选
                    //dataBitsCbx.Enabled = true;//“数据位”可选
                    //stopBitsCbx.Enabled = true;//“停止位”可选
                }
                catch
                {
                    MessageBox.Show("串口断开失败", "错误");
                }
            }
        }

        public void CloseComEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(CloseComEvent), sender, e);
                return;
            }

            if (!e.isOpend) //close successfully
            {
                //baudRateCbx.Enabled = false;
                //dataBitsCbx.Enabled = false;
                //stopBitsCbx.Enabled = false;
                //parityCbx.Enabled = false;
                //handshakingcbx.Enabled = false;
            }
        }

        
        public void ComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, SerialPortEventArgs>(ComReceiveDataEvent), sender, e);
                }
                catch (System.Exception)
                {
                    //disable form destroy exception
                }
                return;
            }

          //  for(int i=0;i<e.receivedBytes.Length;i++){
           //     RecBytes[RecNum++] = e.receivedBytes[i];
          //  }

            if (radioButton3.Checked) //display as string 
            {
                this.memoEdit1.MaskBox.AppendText(Encoding.Default.GetString(e.receivedBytes));
            }
            else //display as hex
            {
                if (memoEdit1.Text.Length > 0)
                {
                    memoEdit1.MaskBox.AppendText(" ");
                }
                memoEdit1.MaskBox.AppendText(IController.Bytes2Hex(e.receivedBytes));
            }

            if ((e.receivedBytes[0] == 0x0D) && (e.receivedBytes[e.receivedBytes.Length - 1] == 0x0D))
            {
                memoEdit1.Text += "\r\n";
                switch (e.receivedBytes[1])
                { 
                    case 0xfe:
                        byte[] verbuf = new byte[3];
                        verbuf[0] = e.receivedBytes[2];
                        verbuf[1] = e.receivedBytes[3];
                        verbuf[2] = e.receivedBytes[5];
                        string result = string.Join(".", verbuf);
                        barButtonItem11.Caption = "固件版本:" + result;
                        barButtonItem9.Enabled = true;
                        break;
                    case 0xf1:
                        f3.Output_Status_Show(e.receivedBytes);
                        break;
                    case 0xf9:
                        f3.Note_Message(e.receivedBytes);
                        break;
                    case 0xf8:
                        f3.SingleReverse_Parameter_Display(e.receivedBytes[2], e.receivedBytes[3], e.receivedBytes[4], e.receivedBytes[5],e.receivedBytes[6], e.receivedBytes[6]);
                        break;
                    case 0xe0:
                        f3.Spreadsheet_Content_Show(e.receivedBytes);
                        break;
                    case 0xf0:
                        f3.calibration_process(e.receivedBytes);
                        break;
                }

                //Array.Clear(RecBytes, 0, 32);
                Array.Clear(e.receivedBytes, 0, e.receivedBytes.Length);
                //RecNum = 0;
            }

        }


        public static int UpdateState = 0;//升级状态

        public static string byteToHexStr(byte[] bytes)//将十六进制数组组合成字符串显示
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                    returnStr += " ";
                }
            }
            return returnStr;
        }

        private void button3_Click(object sender, EventArgs e)//“发送数据”
        {
            byte[] SendBytes = null;
            string SendData = memoEdit2.Text;//需要发送的数据
            List<string> SendDataList = new List<string>();//字符两两存一个

            try
            {
                if (radioButton1.Checked == true)//1.字符型发送
                    serialPort1.WriteLine(SendData);
                else//2.十六进制发送
                {
                    //剔除所有空格
                    SendData = SendData.Replace("\n", "").Replace(" ", "").Replace("\r", "");
                    //每两个字符放进认为一个字节

                    for (int i = 0; i < SendData.Length; i = i + 2)
                    {
                        if (SendData.Length - i == 1)
                            SendDataList.Add(SendData.Substring(i, 1));
                        else
                            SendDataList.Add(SendData.Substring(i, 2));
                    }
                    SendBytes = new byte[SendDataList.Count];//创建发送数组
                    try
                    {
                        for (int j = 0; j < SendBytes.Length; j++)
                        {
                            SendBytes[j] = (byte)(Convert.ToInt32(SendDataList[j], 16));//把单个字符转十六进制
                        }
                        serialPort1.Write(SendBytes, 0, SendBytes.Length);
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的十六进制数", "提示");
                    }
                }
            }
            catch
            {
                MessageBox.Show("串口通讯错误", "错误");
            }
        }

        private void sendtbx_KeyPress(object sender, KeyPressEventArgs e)//TextBox输入事件
        {
            if(radioButton2.Checked == true)//十六进制发送，限定输入值
                e.Handled = "0123456789ABCDEF \b".IndexOf(char.ToUpper(e.KeyChar)) < 0;
        }



        
        private void timer1_Tick(object sender, EventArgs e)//定时器（1s）
        {
            bool AutosendFlag = false;
            int AutosendPeriod = 1;
            
            TimerMScounter++;
            if (TimerMScounter > 1000000000)
                TimerMScounter = 0;
            if (checkBox2.Checked == true)
            {
                AutosendFlag = true;
                AutosendPeriod = Convert.ToInt32(textBox4.Text);
            }
            if (AutosendFlag)
            {
                if (TimerMScounter % AutosendPeriod == 0)
                {
                    TimerMScounter = 0;
                    button3_Click(sender, e);
                }
            }
           
        }

        public static byte ByteToBCD(byte b)//byte转BCD
        {           
            byte b1 = (byte)(b / 10);//高四位         
            byte b2 = (byte)(b % 10);//低四位  

            return (byte)((b1 << 4) | b2);
        }

        public void TransmitData(byte[] Data)
        {
            controller.SendDataToCom(Data);
        }

        private void query_mode_button_Click(object sender, EventArgs e)//查询终端
        {
            byte[] SendBytes = new byte[8];

            try
            {
                SendBytes[0] = 0x0D;
                SendBytes[1] = 0xFE;//查询
                SendBytes[2] = 0x00;
                SendBytes[3] = 0X00;
                SendBytes[4] = 0X00;
                SendBytes[5] = 0X00;
                SendBytes[6] = 0x00;
                SendBytes[7] = 0x0D;
                controller.SendDataToCom(SendBytes);
            }
            catch
            {
                MessageBox.Show("串口通讯错误","错误");
            }
        }

        private void start_button_Click(object sender, EventArgs e)//复位终端
        {
            Form3 frm = new Form3(this);//首先实例化
            f3 = frm;
            frm.ShowDialog();
        }

        public void ResetMessages(byte e)
        {
            if (this.InvokeRequired)//1.代理
            {
                this.Invoke(new MethodInvoker(delegate
                {
                }));
            }
            else//2.正常
            {
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (memoEdit2.Text != "")
            {
                if (radioButton2.Checked == true)//切换到十六进制
                {
                    byte[] array = System.Text.Encoding.ASCII.GetBytes(memoEdit2.Text);
                    string ASCIIstr2 = null;
                    for(int i = 0; i < array.Length; i++)
                    {
                        int asciicode = (int)(array[i]);
                        ASCIIstr2 += (Convert.ToString(asciicode, 16).ToUpper().PadLeft(2,'0') + " ");
                    }
                    memoEdit2.Text = ASCIIstr2;
                }
                else
                {
                    byte[] CharBytes = null;
                    List<string> CharDataList = new List<string>();//字符两两存一个
                    //剔除所有空格
                    string charstring = memoEdit2.Text.Replace(" ", "").Replace("\r", "");
                    //每两个字符放进认为一个字节

                    for (int i = 0; i < charstring.Length; i = i + 2)
                    {
                        if (charstring.Length - i == 1)
                            CharDataList.Add(charstring.Substring(i, 1));
                        else
                            CharDataList.Add(charstring.Substring(i, 2));
                    }
                    CharBytes = new byte[CharDataList.Count];//创建发送数组

                    for (int j = 0; j < CharBytes.Length; j++)
                    {
                        CharBytes[j] = (byte)(Convert.ToInt32(CharDataList[j], 16));//把单个字符转十六进制
                    }
                    memoEdit2.Text = System.Text.Encoding.ASCII.GetString(CharBytes);
                }
            }
        }



        private void firmware_version_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            serialctr frm = new serialctr(this);//首先实例化
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form2 frm = new Form2(this);//首先实例化
            frm.ShowDialog();
        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
            memoEdit1.ScrollToCaret();
        }

        private void memoEdit2_EditValueChanged(object sender, EventArgs e)
        {
            memoEdit2.SelectionStart = memoEdit2.Text.Length;
            memoEdit2.ScrollToCaret();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.memoEdit1.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.memoEdit2.Text = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            String sendText = memoEdit2.Text;
            bool flag = false;
            if (sendText == null)
            {
                return;
            }
            //set select index to the end
            memoEdit2.SelectionStart = memoEdit2.MaskBox.TextLength;

            if (radioButton3.Checked)
            {
                flag = controller.SendDataToCom(sendText);
            }
            else
            {
                Byte[] bytes = IController.Hex2Bytes(sendText);
                flag = controller.SendDataToCom(bytes);
            }

            if (!flag)
            {
                MessageBox.Show("数据发送", "失败");
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            byte[] SendBytes = new byte[8];

            try
            {
                SendBytes[0] = 0x0D;
                SendBytes[1] = 0xFE;//查询
                SendBytes[2] = 0x00;
                SendBytes[3] = 0X00;
                SendBytes[4] = 0X00;
                SendBytes[5] = 0X00;
                SendBytes[6] = 0x00;
                SendBytes[7] = 0x0D;
                controller.SendDataToCom(SendBytes);
            }
            catch
            {
                MessageBox.Show("串口通讯错误", "错误");
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form3 frm = new Form3(this);//首先实例化
            f3 = frm;
            frm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
