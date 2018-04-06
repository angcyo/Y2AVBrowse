using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using HtmlAgilityPack;
using System.IO;

namespace Y2AVBrowse
{
    public partial class Form1 : Form
    {
        ArrayList datas, //所有数据
            clickItems,//点击的item
            loadedItems;//保存加载过的网址
        string currentUrl = "";
        Thread thread;
        int lastIndex = 0;//
        static int LOADING = 1;
        static int LOADED = 0;
        int STATE = LOADED;

        public static bool isVerifyOK = false;
        public static string VerifyCode = "";

        public Form1()
        {
            InitializeComponent();
            clickItems = new ArrayList();
            datas = new ArrayList();
            loadedItems = new ArrayList();

            flowLayoutPanel1.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel1, true, null);

            try
            {
                var v = new HtmlWeb();
            }
            catch (Exception e)
            {
                addTip("请注意: HtmlAgilityPack.dll 文件丢失.");
            }

            var thread = new Thread(new ThreadStart(getVerifyCode));
            thread.Start();
        }

        delegate void addItemCallback(int index, AVItem item);
        delegate void addTipCallback(String tip);
        delegate void loadStartCallback();
        delegate void loadEndCallback();

        public static void getVerifyCode()
        {
            try { VerifyCode = HttpUtil.getSourceFromUrl(HttpUtil.VerifyUrl, Encoding.UTF8).Split('=')[1]; }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void addItem(int index, AVItem item)
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                this.Invoke(new addItemCallback(addItem), new object[] { index, item });
            }
            else
            {
                var x = 10;
                var y = 10;
                var boxW = 250;
                var boxH = 350;

                var box = new PictureBox();//图片
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Size = new Size(boxW, boxH);
                box.Location = new Point(x, y);
                box.ImageLocation = item.ImgUrl;

                var type = new Label();//类别
                type.Text = item.Type;
                type.Location = new Point(x, y + boxH);
                type.AutoSize = true;

                var lable = new Label();//标题
                lable.Text = item.Title;
                lable.Location = new Point(x, y + boxH + type.Size.Height);
                lable.AutoSize = true;

                var pan = new Panel();
                pan.Tag = index;

                pan.AutoSize = true;
                box.Enabled = false;
                pan.Controls.Add(box);
                pan.Controls.Add(type);
                pan.Controls.Add(lable);
                pan.Padding = new Padding(10);

                pan.Click += new EventHandler(panel_click);
                flowLayoutPanel1.Controls.Add(pan);
            }


        }

        private void flowLayout_MouseWheel(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("msg");

            // 处理鼠标滚动事件
            // 此处判断鼠标是否在 Panel 区域中，如果不在则不响应滚动
            var pnlRightRectToForm = this.flowLayoutPanel1.ClientRectangle; // 获得Panel的矩形区域
            pnlRightRectToForm.Offset(this.flowLayoutPanel1.Location);            // 将Panel矩形区域转换为在Form空间中的占据区域
            if (!pnlRightRectToForm.Contains(e.Location))                 // 若当前鼠标位置点不在Panel区域中时
                return;

            var pos = new Point();
            if (e.Delta < 0) // 向下滚动
            {
                pos.X = -this.flowLayoutPanel1.AutoScrollPosition.X; // 由于获取AutoScrollPosition的值为实际滚动值的负值
                pos.Y = -this.flowLayoutPanel1.AutoScrollPosition.Y + 50; // 故在此重新设置需要的滚动到的新值（位置值）
            }
            else // 向上滚动
            {
                pos.X = -this.flowLayoutPanel1.AutoScrollPosition.X;
                pos.Y = -this.flowLayoutPanel1.AutoScrollPosition.Y - 50;
            }
            if (Math.Abs(e.Delta) > 10)
            {
                this.flowLayoutPanel1.AutoScrollPosition = pos; // 切记获取AutoScrollPosition 与设置它的值所得结果并不相同
                this.flowLayoutPanel1.AutoScrollPosition = pos;
            }

        }

        private void panel_click(object sender, EventArgs e)
        {
            var pan = (Panel)sender;
            var index = (Int32)pan.Tag;
            var item = (AVItem)datas[index];
            if (clickItems.Contains(index))
            {
                addTip("已从下载列表移除..");
                pan.BackColor = Color.Transparent;
                listBox_down.Items.Remove(item.DownUrl);
                clickItems.Remove(index);
            }
            else
            {
                addTip("已添加到下载列表..");
                pan.BackColor = Color.DeepPink;
                listBox_down.Items.Add(item.DownUrl);
                clickItems.Add(index);
            }

            if (checkBox_copy_img.Checked)
            {
                setDataToClip(item.DownUrl);
            }

            showListTip();
            flowLayoutPanel1.Focus();
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            if (!isVerifyOK)
            {
                var form = new Form2();
                form.ShowDialog();
                return;
            }

            var url = getUrl();
            if (loadedItems.Contains(url))
            {
                addTip("已经加载过了..." + url);
            }
            else
            {
                currentUrl = url;
                loading();
            }
        }

        private void loadStart()
        {
            if (button_next.InvokeRequired)
            {
                this.Invoke(new loadStartCallback(loadStart), null);
            }
            else
            {
                addTip("请稍等...淫片加载中..." + currentUrl);
                button_get.Enabled = false;
                button_next.Enabled = false;
                button_prev.Enabled = false;

            }

        }

        private void loadEnd()
        {
            if (button_next.InvokeRequired)
            {
                this.Invoke(new loadEndCallback(loadEnd), null);
            }
            else
            {

                var page = HttpUtil.GetPageFromUrl(currentUrl);
                if (page == 1)//如果不是首页
                {
                    button_prev.Enabled = false;
                }
                else
                {
                    button_prev.Enabled = true;
                }
                button_get.Enabled = true;
                button_next.Enabled = true;
            }
        }

        private void loading()
        {
            thread = new Thread(new ThreadStart(LoadData));
            thread.Start();
        }

        //从单选按钮中,获取选择的url
        private string getUrl()
        {
            if (radioButton_0.Checked)
            {
                HttpUtil.index = HttpUtil.index_0;
            }
            else if (radioButton_1.Checked)
            {
                HttpUtil.index = HttpUtil.index_1;
            }
            else if (radioButton_2.Checked)
            {
                HttpUtil.index = HttpUtil.index_2;
            }
            else if (radioButton_3.Checked)
            {
                HttpUtil.index = HttpUtil.index_3;
            }


            var url = HttpUtil.index;


            if (radioButton1.Checked)
            {
                url += HttpUtil.index1;
            }
            else if (radioButton2.Checked)
            {
                url += HttpUtil.index2;
            }
            else if (radioButton3.Checked)
            {
                url += HttpUtil.index3;
            }
            else if (radioButton4.Checked)
            {
                url += HttpUtil.index4;
            }
            else if (radioButton5.Checked)
            {
                url += HttpUtil.index5;
            }
            else if (radioButton6.Checked)
            {
                url += HttpUtil.index6;

            }
            else if (radioButton7.Checked)
            {
                url += HttpUtil.index7;
            }
            else if (radioButton8.Checked)
            {
                url += HttpUtil.index8;
            }

            return url;
        }

        private void LoadData()
        {
            STATE = LOADING;
            loadStart();

            //var lastIndex = datas.Count;//之前含有的数据
            var newdatas = HttpUtil.Load(currentUrl);
            datas.AddRange(newdatas);
            Console.WriteLine("数量:" + newdatas.Count);
            if (newdatas.Count == 1)//如果是1,返回的是错误信息
            {
                addTip(newdatas[0].ToString());
            }
            if (newdatas.Count > 1)
            {
                loadedItems.Add(currentUrl);//保存加载成功的url
                var index = 0;
                foreach (AVItem data in newdatas)
                {
                    addItem(index + lastIndex, data);
                    index++;
                }
                lastIndex += index;
                addTip("为你提供了 " + index + " 个,高清淫片,请慢用.");
            }
            STATE = LOADED;
            loadEnd();
        }

        private void addTip(String tip)
        {
            if (label_tip.InvokeRequired)
            {
                this.Invoke(new addTipCallback(addTip), new object[] { tip });
            }
            else
            {
                tip = tip.Replace(HttpUtil.index, "******");
                label_tip.Text = tip + " --> " + getTime();
            }
        }

        private void showListTip()
        {
            label_list.Text = "可下载--> " + listBox_down.Items.Count + " 个.";
        }

        public static String getTime()
        {
            var dt = DateTime.Now;
            return dt.ToLongTimeString().ToString();//2005-11-5 21:21:25
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(flowLayout_MouseWheel);
            update_layout();
        }

        private void update_layout()
        {
            var margin = 40;
            var form_height = this.Size.Height;
            var form_width = this.Size.Width;

            var listBox_width = listBox_down.Size.Width;
            var listBox_height = listBox_down.Size.Height;
            var listBox_Top = listBox_down.Location.Y;
            listBox_down.Size = new Size(listBox_width, form_height - listBox_Top - margin);

            var flow_left = flowLayoutPanel1.Location.X;
            var flow_top = flowLayoutPanel1.Location.Y;
            flowLayoutPanel1.Size = new Size(form_width - flow_left - 20, form_height - flow_top - 2 * margin);

            label_tip.Location = new Point(flow_left, flowLayoutPanel1.Size.Height + flow_top + 10);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (STATE == LOADING)
            {
                return;
            }

            var url = getUrl();
            if (currentUrl == url)
            {
                var page = HttpUtil.GetPageFromUrl(currentUrl);
                if (page == 1)//如果不是首页
                {
                    button_prev.Enabled = false;
                }
                else
                {
                    button_prev.Enabled = true;
                }
                button_get.Enabled = true;
                button_next.Enabled = true;
            }
            else
            {
                button_prev.Enabled = false;
                button_get.Enabled = true;
                button_next.Enabled = false;
            }

        }

        private void listBox_down_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_list_copy.Checked)
            {
                setDataToClip(listBox_down.SelectedItem);
            }
        }

        private static void setDataToClip(object obj)
        {
            Clipboard.SetDataObject(obj);
        }

        private void listBox_down_DataSourceChanged(object sender, EventArgs e)
        {
            label_list.Text = "可下载: " + listBox_down.Items.Count + " 个.";
        }

        private void listBox_down_ValueMemberChanged(object sender, EventArgs e)
        {
            label_list.Text = "可下载: " + listBox_down.Items.Count + " 个.";
        }

        private void listBox_down_FormatStringChanged(object sender, EventArgs e)
        {
            label_list.Text = "可下载--> " + listBox_down.Items.Count + " 个.";
        }

        private void listBox_down_BindingContextChanged(object sender, EventArgs e)
        {
        }

        private void listBox_down_CursorChanged(object sender, EventArgs e)
        {
            label_list.Text = "可下载:-> " + listBox_down.Items.Count + " 个.";
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            var page = HttpUtil.GetPageFromUrl(currentUrl);
            var url = HttpUtil.GetPageUrl(getUrl(), page + 1);
            if (loadedItems.Contains(url))
            {
                addTip("已经加载过了..." + url);
            }
            else
            {
                currentUrl = url;
                loading();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (listBox_down.Items.Count == 0)
            {
                addTip("下载地址列表为空");
                return;
            }
            try
            {
                var sw = File.AppendText(saveFileDialog1.FileName);

                foreach (var text in listBox_down.Items)
                {
                    sw.WriteLine(text);
                }
                sw.Flush();
                sw.Close();

                addTip("已保存至..-->" + saveFileDialog1.FileName);
            }
            catch (Exception ee)
            {
                addTip("写入文件出错..." + ee.Message);
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (listBox_down.Items.Count == 0)
            {
                addTip("下载地址列表为空");
                return;
            }
            saveFileDialog1.ShowDialog();
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            var page = HttpUtil.GetPageFromUrl(currentUrl);
            var url = HttpUtil.GetPageUrl(getUrl(), page - 1);
            if (loadedItems.Contains(url))
            {
                addTip("已经加载过了..." + url);
            }
            else
            {
                currentUrl = url;
                loading();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            update_layout();
            this.MouseWheel += new MouseEventHandler(flowLayout_MouseWheel);
        }
    }
}
