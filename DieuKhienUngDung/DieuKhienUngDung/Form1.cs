using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using KAutoHelper;
namespace DieuKhienUngDung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Process start notepad
            Process.Start("notepad");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Process start notepad
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            //Process file name chúa url 
            process.StartInfo.FileName= "D:\\ảnh\\105APPLE\\IMG_5001.jpg";
            process.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string content = "/C ping -t howkteam.com";
            //Process mở cmd và attribute đầu vào là nội dung để run CMD
            Process.Start("CMD.exe", content);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = @"/C ""D:\\ảnh\\105APPLE\\IMG_5001.jpg""";

            Process p = new Process();
            //Process mở cmd và attribute đầu vào là nội dung để run CMD
            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = strCmdText;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

            //p.Kill();

            /*
             
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C ""How Kteam - Free Education.html""";
            process.StartInfo = startInfo;
            process.Start();
             
             */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "ping howkteam.com";

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //Process mở cmd và attribute đầu vào là nội dung để run CMD
            startInfo.FileName = "CMD.exe";
            //Không xuất hiện window cmd
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //Xét cờ input
            startInfo.RedirectStandardInput = true;
            //Xét cờ output
            startInfo.RedirectStandardOutput = true;
            p.StartInfo = startInfo;
            //start cmd
            p.Start();
            //Viết ra cmd nội dung muốn thực hiện
            p.StandardInput.WriteLine(strCmdText);
            //Làm sạch data
            p.StandardInput.Flush();
            //Đóng
            p.StandardInput.Close();
            //Chờ xử lý thực hiện xong
            p.WaitForExit();
            //Get toàn bộ ouput trả về
            string result = p.StandardOutput.ReadToEnd();

            MessageBox.Show(result);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            //Cursor.Position = new Point(x,y);
            AutoControl.MouseClick(x, y, mouseKey);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;
            //Lấy name mainwindow
            // var name = Process.GetProcessById(21964);
            // MessageBox.Show(name.ProcessName);
            //Set mainWindowHandle
            //var hWnd = Process.GetProcessById(12012).MainWindowHandle;
            //var hWnd = Process.GetProcessesByName("Remote Desktop Connection")[0].MainWindowHandle;
            IntPtr hWnd = IntPtr.Zero;
            //Lấy name ứng dụng muốn lấy tọa độ
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(hWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;
            IntPtr hWnd = IntPtr.Zero;
            //Lấy name ứng dụng muốn lấy tọa độ
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ
            IntPtr hWndChil = IntPtr.Zero;
            hWndChil = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);
            var pointToClick = AutoControl.GetGlobalPoint(hWndChil, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }
    }
}
