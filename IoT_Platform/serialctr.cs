using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firmware_Update_V1._0
{
    public partial class serialctr : Form
    {
        private Form1 f1;
        public serialctr()
        {
            InitializeComponent();

        }

        public serialctr(Form1 frm1)
        {
            InitializeComponent();
            f1 = frm1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.serialBaudrate.SelectedIndex = 3;//波特率默认“115200”
            this.serialParity.SelectedIndex = 0;//校验位默认“None”
            this.serialNumbit.SelectedIndex = 3;//数据位默认“8”
            this.serialStopbit.SelectedIndex = 0;//停止位默认“1”
            this.serialFlowctr.SelectedIndex = 0;//流控位默认“0”
        }

        private void serialComscan_Click(object sender, EventArgs e)
        {
            f1.scan_combox(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serialConnect_Click(object sender, EventArgs e)
        {
            if (serialConnect.Text == "连接")
            {
                serialConnect.Text = "断开";
            }
            else {
                serialConnect.Text = "连接";
            }
        }

    }
}
