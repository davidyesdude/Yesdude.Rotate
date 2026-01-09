using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yesdude.Rotate
{
    public partial class FormScreenNumber : Form
    {
        private System.Windows.Forms.Timer closeTimer;

        public FormScreenNumber()
        {
            InitializeComponent();

            closeTimer = new System.Windows.Forms.Timer();
            // Set the interval to 5000 milliseconds (5 seconds)
            closeTimer.Interval = 5000;
            // Hook up the event handler for the Tick event
            closeTimer.Tick += CloseTimer_Tick;
        }

        public void ScreenNumber(int screenId)
        {
            this.labelNumber.Text = screenId.ToString();
        }

        public void SetTransparency()
        {
            Color foreColor = Color.FromArgb(0, 0, 128, 0);
            Color transparentColor = Color.LightSeaGreen;
            this.ForeColor = foreColor;
            this.BackColor = transparentColor;
            this.TransparencyKey = transparentColor;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void CenterScreen()
        {
            this.CenterToScreen();
        }

        private void FormScreenNumber_Load(object sender, EventArgs e)
        {
            closeTimer = new System.Windows.Forms.Timer()
            {
                Interval = 3000
            };
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }

        private void FormScreenNumber_Click(object sender, EventArgs e)
        {
            Just_Close();
        }

        private void labelNumber_Click(object sender, EventArgs e)
        {
            Just_Close();
        }

        private void labelNumber_MouseMove(object sender, MouseEventArgs e)
        {
            Just_Close();
        }

        private void CloseTimer_Tick(object? sender, EventArgs e)
        {
            Just_Close();
        }

        private void Just_Close()
        {
            this.Close();
        }

    }
}
