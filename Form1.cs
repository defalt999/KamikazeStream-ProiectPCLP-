using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamikazeStream
{  
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
            bagapoze();

        }
        
        bool menuExtend;
        private void button5_Click(object sender, EventArgs e)
        {

            sidebarTimer.Start();

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (menuExtend)
            {
                sideBar.Width -= 50;
                if (sideBar.Width == sideBar.MinimumSize.Width)
                {
                    menuExtend = false;
                    sidebarTimer.Stop();
                }
            }else{
                sideBar.Width += 50;
                if (sideBar.Width == sideBar.MaximumSize.Width)
                {
                    menuExtend = true;
                    sidebarTimer.Stop();
                }
            }
        }
        private void bagapoze()
        {
            string imaginiFolder=Path.Combine(Application.StartupPath, "C:\\Users\\1defa\\OneDrive\\Desktop\\milfs");
            if (!Directory.Exists(imaginiFolder))
            {
                MessageBox.Show("Nu s-a gasit folderul.", "Eroare boss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] pozeFilme = Directory.GetFiles(imaginiFolder, "*.jpg");
            foreach(var imagine in pozeFilme)
            {
                PictureBox picturebox = new PictureBox();
                picturebox.Image = Image.FromFile(imagine);
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.Width = 200;
                picturebox.Height = 300;
                picturebox.Margin = new Padding(10);

                flowLayoutPanel1.Controls.Add(picturebox);

            }
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.Size = new Size(800, 500);
            //Cod de pe net ca sa nu flickereasca pozele
            //==============================================
            flowLayoutPanel1.Scroll += FlowLayoutPanel_Scroll;
             void FlowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
            {
                Application.DoEvents();
            }
            //=============================================



        }
    }
}
