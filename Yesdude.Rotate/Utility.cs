using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yesdude.Rotate
{
    internal class Utility
    {

        public static void CreateTextIcon(string str, ref NotifyIcon trayIcon)
        {
            Font fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(Color.White);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);
            g.Clear(Color.Green);

            IntPtr hIcon;

            //g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, fontToUse, brushToUse, 0, -2);
            //g.DrawIcon(GetResourceIcon(), new Rectangle() { Height = 16,Width = 16, X = 0, Y = 0 });
            hIcon = (bitmapText.GetHicon());
            Icon icon = System.Drawing.Icon.FromHandle(hIcon);
            trayIcon.Icon = (Icon)icon.Clone();
            icon.Dispose();

        }
    }
}
