using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KamikazeStream
{
    public partial class Form1 : Form
    {
        private List<Film> filme;

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

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Hand;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Default;
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (menuExtend)
            {
                sideBar.Width -= 50;
                if (sideBar.Width <= sideBar.MinimumSize.Width)
                {
                    menuExtend = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sideBar.Width += 50;
                if (sideBar.Width >= sideBar.MaximumSize.Width)
                {
                    menuExtend = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void bagapoze()
        {
            string jsonPath = "C:\\Deflat C++\\KamikazeStream-ProiectPCLP\\dateFilme.json";

            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Nu e jsonu");
                return;
            }

            try
            {
                string json = File.ReadAllText(jsonPath);
                filme = JsonConvert.DeserializeObject<List<Film>>(json);

                foreach (var film in filme)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = 200;
                    pictureBox.Height = 300;
                    pictureBox.Margin = new Padding(10);

                    
                    if (File.Exists(film.ImagePath))
                    {
                        pictureBox.Image = Image.FromFile(film.ImagePath);
                    }
                    else
                    {
                        MessageBox.Show("Nu e imaginea");
                        continue; 
                    }

                    
                    pictureBox.Click += (sender, e) => ShowMovieDetails(film);

                    flowLayoutPanel1.Controls.Add(pictureBox);
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
            catch (Exception ex)
            {
                MessageBox.Show("Eroare");
            }
        }

        private void ShowMovieDetails(Film film)
        {
            Form2 movieDetailsForm = new Form2();
            movieDetailsForm.SetMovieDetails(film);
            movieDetailsForm.Text = film.Title;
            movieDetailsForm.ShowDialog();
        }

        
    }
}
