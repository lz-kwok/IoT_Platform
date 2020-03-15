namespace Firmware_Update_V1._0
{
    partial class serialctr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serialctr));
            this.serialComscan = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.serialFlowctr = new System.Windows.Forms.ComboBox();
            this.serialConnect = new DevExpress.XtraEditors.SimpleButton();
            this.serialNumbit = new System.Windows.Forms.ComboBox();
            this.serialStopbit = new System.Windows.Forms.ComboBox();
            this.serialParity = new System.Windows.Forms.ComboBox();
            this.serialBaudrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialComscan
            // 
            this.serialComscan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("serialComscan.ImageOptions.Image")));
            this.serialComscan.Location = new System.Drawing.Point(401, 17);
            this.serialComscan.Name = "serialComscan";
            this.serialComscan.Size = new System.Drawing.Size(117, 40);
            this.serialComscan.TabIndex = 0;
            this.serialComscan.Text = "扫描";
            this.serialComscan.Click += new System.EventHandler(this.serialComscan_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "端口号";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.serialFlowctr);
            this.panelControl1.Controls.Add(this.serialConnect);
            this.panelControl1.Controls.Add(this.serialNumbit);
            this.panelControl1.Controls.Add(this.serialComscan);
            this.panelControl1.Controls.Add(this.serialStopbit);
            this.panelControl1.Controls.Add(this.serialParity);
            this.panelControl1.Controls.Add(this.serialBaudrate);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.comboBox1);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(9, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(529, 118);
            this.panelControl1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(208, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "流  控";
            // 
            // serialFlowctr
            // 
            this.serialFlowctr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialFlowctr.FormattingEnabled = true;
            this.serialFlowctr.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.serialFlowctr.Location = new System.Drawing.Point(264, 77);
            this.serialFlowctr.Name = "serialFlowctr";
            this.serialFlowctr.Size = new System.Drawing.Size(121, 22);
            this.serialFlowctr.TabIndex = 12;
            // 
            // serialConnect
            // 
            this.serialConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("serialConnect.ImageOptions.Image")));
            this.serialConnect.Location = new System.Drawing.Point(401, 63);
            this.serialConnect.Name = "serialConnect";
            this.serialConnect.Size = new System.Drawing.Size(117, 40);
            this.serialConnect.TabIndex = 4;
            this.serialConnect.Text = "连接";
            this.serialConnect.Click += new System.EventHandler(this.serialConnect_Click);
            // 
            // serialNumbit
            // 
            this.serialNumbit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialNumbit.FormattingEnabled = true;
            this.serialNumbit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.serialNumbit.Location = new System.Drawing.Point(264, 19);
            this.serialNumbit.Name = "serialNumbit";
            this.serialNumbit.Size = new System.Drawing.Size(121, 22);
            this.serialNumbit.TabIndex = 11;
            // 
            // serialStopbit
            // 
            this.serialStopbit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialStopbit.FormattingEnabled = true;
            this.serialStopbit.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two"});
            this.serialStopbit.Location = new System.Drawing.Point(264, 49);
            this.serialStopbit.Name = "serialStopbit";
            this.serialStopbit.Size = new System.Drawing.Size(121, 22);
            this.serialStopbit.TabIndex = 10;
            // 
            // serialParity
            // 
            this.serialParity.AutoCompleteCustomSource.AddRange(new string[] {
            "None",
            "Even",
            "Mark"});
            this.serialParity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialParity.FormattingEnabled = true;
            this.serialParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Mark",
            "Odd",
            "Space"});
            this.serialParity.Location = new System.Drawing.Point(73, 77);
            this.serialParity.Name = "serialParity";
            this.serialParity.Size = new System.Drawing.Size(121, 22);
            this.serialParity.TabIndex = 9;
            // 
            // serialBaudrate
            // 
            this.serialBaudrate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialBaudrate.FormattingEnabled = true;
            this.serialBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "115200"});
            this.serialBaudrate.Location = new System.Drawing.Point(73, 48);
            this.serialBaudrate.Name = "serialBaudrate";
            this.serialBaudrate.Size = new System.Drawing.Size(121, 22);
            this.serialBaudrate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(208, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(208, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "校验位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "波特率";
            // 
            // serialctr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 134);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "serialctr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "串口设置";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton serialComscan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox serialBaudrate;
        private System.Windows.Forms.ComboBox serialParity;
        private System.Windows.Forms.ComboBox serialStopbit;
        private System.Windows.Forms.ComboBox serialNumbit;
        private DevExpress.XtraEditors.SimpleButton serialConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox serialFlowctr;



    }
}