using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.;
using System.IO;
using System.Xml;
using Microsoft.SqlServer.Server;

namespace Yesdude.Rotate
{
    //internal static class Program
    //{
    //    /// <summary>
    //    ///  The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        // To customize application configuration such as set high DPI settings or default font,
    //        // see https://aka.ms/applicationconfiguration.
    //        ApplicationConfiguration.Initialize();
    //        Application.Run(new Form1());
    //    }
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string processName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? "Yesdude.Rotate";
            string machineName = Environment.MachineName;

            using (var mutex = new Mutex(false, machineName + "_" + processName))
            {
                bool isAnotherInstanceInMemory = !mutex.WaitOne(TimeSpan.Zero);
                if (isAnotherInstanceInMemory) return;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new ScreenRotater());

                mutex.ReleaseMutex();
            }

        }
    }


    public class ScreenRotater : ApplicationContext
    {
        private NotifyIcon? trayIcon;
        private List<NotifyIcon> trayIcons = new List<NotifyIcon>();

        public ScreenRotater()
        {
            AddTrayIconPerScreen();
        }

        private void AddTrayIconPerScreen()
        {
            Screen[] screens = Screen.AllScreens;

            //You might be compelled to use Screen.AllScreens
            //I didn't find it quite as useful.
            //You may find the tray icons loading misnumbered.  
            //This is a known issue. Restart windows. 
            //Typically it happens during a hardware change
            //like docked to undocked.

            List<int> list = new List<int>();

            for (int DisplayNumber = 1; DisplayNumber < 10; DisplayNumber++)
            {
                if (!Display.VerifyDisplayNumber((uint)DisplayNumber))
                    break;
                else
                    list.Add(DisplayNumber);
            }
            foreach(int item in list) 
                AddTrayIcon(item);
        }

        private void AddTrayIcon(int DisplayNumber)
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon();
            //trayIcon.Icon = Utility.GetResourceIcon();
            Utility.CreateTextIcon(DisplayNumber.ToString(), ref trayIcon);

            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Tag = DisplayNumber;


            trayIcon.ContextMenuStrip.Items.Add("Identify");
            trayIcon.ContextMenuStrip.Items.Add("Normal Landscape");
            trayIcon.ContextMenuStrip.Items.Add("Rotate 90");
            trayIcon.ContextMenuStrip.Items.Add("Rotate 180");
            trayIcon.ContextMenuStrip.Items.Add("Rotate 270");

            trayIcon.ContextMenuStrip.Items.Add("Exit");

            trayIcon.ContextMenuStrip.Items[0].Tag = 1000;
            trayIcon.ContextMenuStrip.Items[1].Tag = 0;
            trayIcon.ContextMenuStrip.Items[2].Tag = 90;
            trayIcon.ContextMenuStrip.Items[3].Tag = 180;
            trayIcon.ContextMenuStrip.Items[4].Tag = 270;

            trayIcon.ContextMenuStrip.Items[5].Tag = -1;

            trayIcon.ContextMenuStrip.ItemClicked += ContextMenuStrip_Click;

            trayIcon.Visible = true;
            trayIcons.Add(trayIcon);
        }

        private void ContextMenuStrip_Click(object? sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip actionItem = new ContextMenuStrip();
            if(sender != null ) actionItem = (ContextMenuStrip)sender;

            int screenId = 0;
            int rotation = 0;

            if(!Int32.TryParse(actionItem?.Tag?.ToString(), out screenId)) return;
            if(!Int32.TryParse(e.ClickedItem?.Tag?.ToString(), out rotation)) return;

            switch (rotation)
            {
                case -1:
                    foreach(NotifyIcon ti in trayIcons)
                        ti.Visible = false;
                    Application.Exit();
                    break;
                case 0:
                    goto default;
                case 90:
                    Display.Rotate((uint)screenId, Display.Orientations.DEGREES_CW_90);
                    break;
                case 180:
                    Display.Rotate((uint)screenId, Display.Orientations.DEGREES_CW_180);
                    break;
                case 270:
                    Display.Rotate((uint)screenId, Display.Orientations.DEGREES_CW_270);
                    break;
                case 1000:
                    Display.Identify((uint)screenId);
                    break;
                default:
                    Display.Rotate((uint)screenId, Display.Orientations.DEGREES_CW_0);
                    break;
            }

        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            if (trayIcon is not null) trayIcon.Visible = false;

            Application.Exit();
        }
    }
}