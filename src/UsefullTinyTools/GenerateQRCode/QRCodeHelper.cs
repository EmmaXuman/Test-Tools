using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using QRCoder;

namespace GenerateQRCode
{
    public static class QRCodeHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">二维码内容</param>
        /// <param name="version">版本</param>
        /// <param name="pixel">像素</param>
        /// <param name="icon_path">图标地址</param>
        /// <param name="icon_size">图标大小</param>
        /// <param name="icon_border">图标边界</param>
        /// <param name="white_edge">二维码白边</param>
        /// <returns></returns>
        public static Bitmap GenerateCode( string msg, int version, int pixel, string icon_path, int icon_size, int icon_border, bool white_edge )
        {
            using var code_generator = new QRCodeGenerator();
            var code_data = code_generator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.M, true, true, QRCodeGenerator.EciMode.Utf8, version);
            var code = new QRCode(code_data);
            var icon = new Bitmap(icon_path);
            var bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);
            return bmp;

        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">二维码内容</param>
        /// <param name="version">版本</param>
        /// <param name="pixel">像素</param>
        /// <param name="icon_path">图标地址</param>
        /// <param name="icon_size">图标大小</param>
        /// <param name="icon_border">图标边界</param>
        /// <param name="white_edge">二维码白边</param>
        /// <returns></returns>
        public static Bitmap GenerateCode( string msg, int version, int pixel, Bitmap icon, int icon_size, int icon_border, bool white_edge )
        {
            using var code_generator = new QRCodeGenerator();
            var code_data = code_generator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.M, true, true, QRCodeGenerator.EciMode.Utf8, version);
            using var code = new QRCode(code_data);

            var bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);
            return bmp;
        }
    }
}
