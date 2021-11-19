using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace NTools2
{
    public partial class NTools : Form
    {

        public Font quicksand;
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        public NTools()
        {
            InitializeComponent();
            byte[] fontData = Properties.Resources.quicksand;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.quicksand.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.quicksand.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            quicksand = new Font(fonts.Families[0], 25.0F);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            title.Font = quicksand;
            quicksand = new Font(fonts.Families[0], 12.0F);
            button1.Font = quicksand;
            button2.Font= quicksand;
            button3.Font= quicksand;
            button4.Font= quicksand;                
            onedriveremover.Font = quicksand;
            efi.Font = quicksand;

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void efi_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C mountvol X: /s";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value = 100;
        }

        private void onedriveremover_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C TASKKILL /f /im OneDrive.exe";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value += 50;
            string getEnv = Environment.GetEnvironmentVariable("systemroot");
            if (File.Exists(getEnv + "\\System32\\OneDriveSetup.exe"))
            {
                strCmdText = "/C %systemroot%\\System32\\OneDriveSetup.exe /uninstall";
                p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                while (!p.HasExited)
                {

                }
            }
            if (File.Exists(getEnv + "\\SysWOW64\\OneDriveSetup.exe"))
            {
                strCmdText = "/C %systemroot%\\SysWOW64\\OneDriveSetup.exe /uninstall";
                p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                while (!p.HasExited)
                {

                }
            }
            progressBar1.Value = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C DEL /F /S /Q %TEMP%";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value += 50;
            strCmdText = "/C cleanmgr.exe /dc";
            p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C sfc /scannow";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value += 50;
            strCmdText = "/C DISM.exe /Online /Cleanup-Image /Restorehealth";
            p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value = 100;
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C Powershell -Command \"Get-AppxPackage -allusers Microsoft.549981C3F5F10 | Remove-AppxPackage\"";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }

            progressBar1.Value = 100;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            string strCmdText;
            strCmdText = "/C netsh winsock reset";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            progressBar1.Value += 50;
            strCmdText = "/C netsh int ip reset";
            p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            while (!p.HasExited)
            {

            }
            MessageBox.Show("You need to restart your computer to finish the process.", "NTools", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 100;
        }
    }
}
