using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Y2AVBrowse
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.VerifyCode==null || Form1.VerifyCode == "")
            {
                var thread = new Thread(new ThreadStart(Form1.getVerifyCode));
                thread.Start();
                label_result.Text = "验证码获取中...";
                return;
            }

            if (textBox1.Text == Form1.VerifyCode)
            {
                this.Dispose();
                Form1.isVerifyOK = true;
            }
            else
            {
                label_result.Text = "验证码错误";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(null,null);
            }
        }
    }
}
