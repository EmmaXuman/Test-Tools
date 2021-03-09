
namespace GenerateQRCode
{
    partial class QrCode
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_qrcode = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_version = new System.Windows.Forms.ComboBox();
            this.cb_icon_size = new System.Windows.Forms.ComboBox();
            this.cb_pixel = new System.Windows.Forms.ComboBox();
            this.cb_icon_border = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_we_y = new System.Windows.Forms.RadioButton();
            this.rb_we_n = new System.Windows.Forms.RadioButton();
            this.bt_generate = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.tb_msg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_qrcode)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_qrcode
            // 
            this.pb_qrcode.Location = new System.Drawing.Point(12, 12);
            this.pb_qrcode.Name = "pb_qrcode";
            this.pb_qrcode.Size = new System.Drawing.Size(325, 282);
            this.pb_qrcode.TabIndex = 0;
            this.pb_qrcode.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "版本：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "图标尺寸：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "像素：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "图标边线：";
            // 
            // cb_version
            // 
            this.cb_version.FormattingEnabled = true;
            this.cb_version.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cb_version.Location = new System.Drawing.Point(88, 307);
            this.cb_version.Name = "cb_version";
            this.cb_version.Size = new System.Drawing.Size(58, 25);
            this.cb_version.TabIndex = 5;
            // 
            // cb_icon_size
            // 
            this.cb_icon_size.FormattingEnabled = true;
            this.cb_icon_size.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40"});
            this.cb_icon_size.Location = new System.Drawing.Point(88, 348);
            this.cb_icon_size.Name = "cb_icon_size";
            this.cb_icon_size.Size = new System.Drawing.Size(58, 25);
            this.cb_icon_size.TabIndex = 6;
            // 
            // cb_pixel
            // 
            this.cb_pixel.FormattingEnabled = true;
            this.cb_pixel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "20",
            "30"});
            this.cb_pixel.Location = new System.Drawing.Point(245, 307);
            this.cb_pixel.Name = "cb_pixel";
            this.cb_pixel.Size = new System.Drawing.Size(56, 25);
            this.cb_pixel.TabIndex = 7;
            // 
            // cb_icon_border
            // 
            this.cb_icon_border.FormattingEnabled = true;
            this.cb_icon_border.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cb_icon_border.Location = new System.Drawing.Point(245, 348);
            this.cb_icon_border.Name = "cb_icon_border";
            this.cb_icon_border.Size = new System.Drawing.Size(56, 25);
            this.cb_icon_border.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "白边：";
            // 
            // rb_we_y
            // 
            this.rb_we_y.AutoSize = true;
            this.rb_we_y.Location = new System.Drawing.Point(98, 390);
            this.rb_we_y.Name = "rb_we_y";
            this.rb_we_y.Size = new System.Drawing.Size(38, 21);
            this.rb_we_y.TabIndex = 10;
            this.rb_we_y.TabStop = true;
            this.rb_we_y.Text = "有";
            this.rb_we_y.UseVisualStyleBackColor = true;
            // 
            // rb_we_n
            // 
            this.rb_we_n.AutoSize = true;
            this.rb_we_n.Location = new System.Drawing.Point(152, 390);
            this.rb_we_n.Name = "rb_we_n";
            this.rb_we_n.Size = new System.Drawing.Size(38, 21);
            this.rb_we_n.TabIndex = 11;
            this.rb_we_n.TabStop = true;
            this.rb_we_n.Text = "无";
            this.rb_we_n.UseVisualStyleBackColor = true;
            // 
            // bt_generate
            // 
            this.bt_generate.Location = new System.Drawing.Point(38, 492);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(75, 23);
            this.bt_generate.TabIndex = 12;
            this.bt_generate.Text = "生成";
            this.bt_generate.UseVisualStyleBackColor = true;
            this.bt_generate.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(204, 492);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 13;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(38, 421);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(274, 50);
            this.tb_msg.TabIndex = 14;
            // 
            // QrCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 536);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_generate);
            this.Controls.Add(this.rb_we_n);
            this.Controls.Add(this.rb_we_y);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_icon_border);
            this.Controls.Add(this.cb_pixel);
            this.Controls.Add(this.cb_icon_size);
            this.Controls.Add(this.cb_version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_qrcode);
            this.Name = "QrCode";
            this.Text = "生成二维码";
            this.Load += new System.EventHandler(this.QrCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_qrcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_qrcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_version;
        private System.Windows.Forms.ComboBox cb_icon_size;
        private System.Windows.Forms.ComboBox cb_pixel;
        private System.Windows.Forms.ComboBox cb_icon_border;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_we_y;
        private System.Windows.Forms.RadioButton rb_we_n;
        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox tb_msg;
    }
}

