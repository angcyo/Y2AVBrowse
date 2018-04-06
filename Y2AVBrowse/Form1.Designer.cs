namespace Y2AVBrowse
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_get = new System.Windows.Forms.Button();
            this.label_tip = new System.Windows.Forms.Label();
            this.listBox_down = new System.Windows.Forms.ListBox();
            this.groupBox_type = new System.Windows.Forms.GroupBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox_cmd = new System.Windows.Forms.GroupBox();
            this.button_next = new System.Windows.Forms.Button();
            this.button_prev = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_list_copy = new System.Windows.Forms.CheckBox();
            this.checkBox_copy_img = new System.Windows.Forms.CheckBox();
            this.label_list = new System.Windows.Forms.Label();
            this.button_export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.radioButton_0 = new System.Windows.Forms.RadioButton();
            this.radioButton_1 = new System.Windows.Forms.RadioButton();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_3 = new System.Windows.Forms.RadioButton();
            this.groupBox_type.SuspendLayout();
            this.groupBox_cmd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(691, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(725, 532);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button_get
            // 
            this.button_get.Location = new System.Drawing.Point(6, 21);
            this.button_get.Name = "button_get";
            this.button_get.Size = new System.Drawing.Size(94, 50);
            this.button_get.TabIndex = 5;
            this.button_get.Text = "Just Get Its";
            this.button_get.UseVisualStyleBackColor = true;
            this.button_get.Click += new System.EventHandler(this.button_get_Click);
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.Location = new System.Drawing.Point(701, 567);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(89, 12);
            this.label_tip.TabIndex = 6;
            this.label_tip.Text = "提示:准备中...";
            // 
            // listBox_down
            // 
            this.listBox_down.FormattingEnabled = true;
            this.listBox_down.HorizontalScrollbar = true;
            this.listBox_down.ItemHeight = 12;
            this.listBox_down.Location = new System.Drawing.Point(18, 208);
            this.listBox_down.Name = "listBox_down";
            this.listBox_down.Size = new System.Drawing.Size(654, 436);
            this.listBox_down.TabIndex = 10;
            this.listBox_down.SelectedIndexChanged += new System.EventHandler(this.listBox_down_SelectedIndexChanged);
            this.listBox_down.DataSourceChanged += new System.EventHandler(this.listBox_down_DataSourceChanged);
            this.listBox_down.FormatStringChanged += new System.EventHandler(this.listBox_down_FormatStringChanged);
            this.listBox_down.ValueMemberChanged += new System.EventHandler(this.listBox_down_ValueMemberChanged);
            this.listBox_down.BindingContextChanged += new System.EventHandler(this.listBox_down_BindingContextChanged);
            this.listBox_down.CursorChanged += new System.EventHandler(this.listBox_down_CursorChanged);
            // 
            // groupBox_type
            // 
            this.groupBox_type.Controls.Add(this.radioButton8);
            this.groupBox_type.Controls.Add(this.radioButton7);
            this.groupBox_type.Controls.Add(this.radioButton6);
            this.groupBox_type.Controls.Add(this.radioButton5);
            this.groupBox_type.Controls.Add(this.radioButton4);
            this.groupBox_type.Controls.Add(this.radioButton3);
            this.groupBox_type.Controls.Add(this.radioButton2);
            this.groupBox_type.Controls.Add(this.radioButton1);
            this.groupBox_type.Location = new System.Drawing.Point(18, 13);
            this.groupBox_type.Name = "groupBox_type";
            this.groupBox_type.Size = new System.Drawing.Size(317, 77);
            this.groupBox_type.TabIndex = 11;
            this.groupBox_type.TabStop = false;
            this.groupBox_type.Text = "口味选择";
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(235, 48);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(71, 16);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.Text = "变态另类";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(159, 48);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(71, 16);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.Text = "制服丝袜";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(83, 48);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(71, 16);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "强奸乱伦";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(7, 48);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(71, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "成人动漫";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(235, 20);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(71, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "经典三级";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(159, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "国产电影";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(83, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "欧美电影";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "亚洲电影";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // groupBox_cmd
            // 
            this.groupBox_cmd.Controls.Add(this.button_next);
            this.groupBox_cmd.Controls.Add(this.button_prev);
            this.groupBox_cmd.Controls.Add(this.button_get);
            this.groupBox_cmd.Location = new System.Drawing.Point(355, 13);
            this.groupBox_cmd.Name = "groupBox_cmd";
            this.groupBox_cmd.Size = new System.Drawing.Size(317, 77);
            this.groupBox_cmd.TabIndex = 12;
            this.groupBox_cmd.TabStop = false;
            this.groupBox_cmd.Text = "命令";
            // 
            // button_next
            // 
            this.button_next.Enabled = false;
            this.button_next.Location = new System.Drawing.Point(206, 21);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(105, 50);
            this.button_next.TabIndex = 7;
            this.button_next.Text = "下一页";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_prev
            // 
            this.button_prev.Enabled = false;
            this.button_prev.Location = new System.Drawing.Point(107, 21);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(92, 50);
            this.button_prev.TabIndex = 6;
            this.button_prev.Text = "上一页";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_3);
            this.groupBox1.Controls.Add(this.radioButton_2);
            this.groupBox1.Controls.Add(this.radioButton_1);
            this.groupBox1.Controls.Add(this.radioButton_0);
            this.groupBox1.Controls.Add(this.checkBox_list_copy);
            this.groupBox1.Controls.Add(this.checkBox_copy_img);
            this.groupBox1.Location = new System.Drawing.Point(18, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 70);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "附加选项 (请确保能访问境外网站)";
            // 
            // checkBox_list_copy
            // 
            this.checkBox_list_copy.AutoSize = true;
            this.checkBox_list_copy.Location = new System.Drawing.Point(7, 44);
            this.checkBox_list_copy.Name = "checkBox_list_copy";
            this.checkBox_list_copy.Size = new System.Drawing.Size(186, 16);
            this.checkBox_list_copy.TabIndex = 1;
            this.checkBox_list_copy.Text = "点击下载地址列表项,复制地址";
            this.checkBox_list_copy.UseVisualStyleBackColor = true;
            // 
            // checkBox_copy_img
            // 
            this.checkBox_copy_img.AutoSize = true;
            this.checkBox_copy_img.Checked = true;
            this.checkBox_copy_img.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_copy_img.Location = new System.Drawing.Point(7, 21);
            this.checkBox_copy_img.Name = "checkBox_copy_img";
            this.checkBox_copy_img.Size = new System.Drawing.Size(174, 16);
            this.checkBox_copy_img.TabIndex = 0;
            this.checkBox_copy_img.Text = "点击图片,直接复制下载地址";
            this.checkBox_copy_img.UseVisualStyleBackColor = true;
            // 
            // label_list
            // 
            this.label_list.AutoSize = true;
            this.label_list.Location = new System.Drawing.Point(18, 185);
            this.label_list.Name = "label_list";
            this.label_list.Size = new System.Drawing.Size(59, 12);
            this.label_list.TabIndex = 14;
            this.label_list.Text = "下载地址:";
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(574, 179);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(98, 23);
            this.button_export.TabIndex = 15;
            this.button_export.Text = "导出下载地址";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "RSen AV|*.txt";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // radioButton_0
            // 
            this.radioButton_0.AutoSize = true;
            this.radioButton_0.Checked = true;
            this.radioButton_0.Location = new System.Drawing.Point(464, 20);
            this.radioButton_0.Name = "radioButton_0";
            this.radioButton_0.Size = new System.Drawing.Size(83, 16);
            this.radioButton_0.TabIndex = 2;
            this.radioButton_0.TabStop = true;
            this.radioButton_0.Text = "默认服务器";
            this.radioButton_0.UseVisualStyleBackColor = true;
            // 
            // radioButton_1
            // 
            this.radioButton_1.AutoSize = true;
            this.radioButton_1.Location = new System.Drawing.Point(463, 42);
            this.radioButton_1.Name = "radioButton_1";
            this.radioButton_1.Size = new System.Drawing.Size(89, 16);
            this.radioButton_1.TabIndex = 3;
            this.radioButton_1.Text = "备用服务器1";
            this.radioButton_1.UseVisualStyleBackColor = true;
            // 
            // radioButton_2
            // 
            this.radioButton_2.AutoSize = true;
            this.radioButton_2.Location = new System.Drawing.Point(555, 21);
            this.radioButton_2.Name = "radioButton_2";
            this.radioButton_2.Size = new System.Drawing.Size(89, 16);
            this.radioButton_2.TabIndex = 4;
            this.radioButton_2.Text = "备用服务器2";
            this.radioButton_2.UseVisualStyleBackColor = true;
            // 
            // radioButton_3
            // 
            this.radioButton_3.AutoSize = true;
            this.radioButton_3.Location = new System.Drawing.Point(555, 42);
            this.radioButton_3.Name = "radioButton_3";
            this.radioButton_3.Size = new System.Drawing.Size(89, 16);
            this.radioButton_3.TabIndex = 5;
            this.radioButton_3.Text = "备用服务器3";
            this.radioButton_3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.label_list);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_cmd);
            this.Controls.Add(this.groupBox_type);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listBox_down);
            this.Controls.Add(this.label_tip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AV浏览器1.1beta by R·Sen (典藏20年)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox_type.ResumeLayout(false);
            this.groupBox_type.PerformLayout();
            this.groupBox_cmd.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_get;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.ListBox listBox_down;
        private System.Windows.Forms.GroupBox groupBox_type;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox_cmd;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_list_copy;
        private System.Windows.Forms.CheckBox checkBox_copy_img;
        private System.Windows.Forms.Label label_list;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton radioButton_3;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.RadioButton radioButton_1;
        private System.Windows.Forms.RadioButton radioButton_0;
    }
}

