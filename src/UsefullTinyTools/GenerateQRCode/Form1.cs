using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQRCode
{
    public partial class QrCode : Form
    {
        public QrCode()
        {
            InitializeComponent();
        }

        private void QrCode_Load( object sender, EventArgs e )
        {
            cb_version.SelectedIndex = 1;
            cb_pixel.SelectedIndex = 0;
            cb_icon_size.SelectedIndex = 0;
            cb_icon_size.SelectedIndex = 1;
        }

        private void bt_generate_Click( object sender, EventArgs e )
        {
            var version = Convert.ToInt16(cb_version.Text);

            var pixel = Convert.ToInt16(cb_pixel.Text);

            string str_msg = tb_msg.Text;

            int int_icon_size = Convert.ToInt16(cb_icon_size.Text);

            int int_icon_border = Convert.ToInt16(cb_icon_size.Text);

            bool b_we = rb_we_y.Checked ? true : false;

            var imgIcon = ImageHelper.UrlToImage("https://uat-oss.ribencun.com/20190517/%E5%85%94%E5%AD%90.png");
            Bitmap bmpIcon = new Bitmap(imgIcon);

            var bmp = QRCodeHelper.GenerateCode(str_msg, version, pixel, bmpIcon, int_icon_size, int_icon_border, b_we);

            pb_qrcode.Image = bmp;
        }

        private void bt_save_Click( object sender, EventArgs e )
        {
            if (pb_qrcode.Image != null)

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "(*.png)|*.png|(*.bmp)|*.bmp";

                    if (sfd.ShowDialog() == DialogResult.OK) pb_qrcode.Image.Save(sfd.FileName);

                }
        }
    }
}
