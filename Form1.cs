﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using NAudio.Wave;

namespace KamikazeStream
{
    public partial class Form1 : Form
    {
        private List<Film> filme;
        private AudioFileReader melodieBck;
        private WaveOutEvent muzica;
       

        public void bagamuzica()
                {
                    melodieBck = new AudioFileReader("C:\\Users\\1defa\\OneDrive\\Desktop\\extra\\backmusic.wav");
                    muzica = new WaveOutEvent();
                    muzica.Init(melodieBck);
                    muzica.Play();
                    

                }
        public Form1()
        {
            InitializeComponent();
            bagapoze();
            bagamuzica();
            
        }

        
        

        bool menuExtend;
        bool afisate;

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
                string json = File.ReadAllText(jsonPath);
                filme = JsonConvert.DeserializeObject<List<Film>>(json);

                foreach (var film in filme)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = 200;
                    pictureBox.Height = 300;
                    pictureBox.Margin = new Padding(10);                   
                    pictureBox.Image = Image.FromFile(film.ImagePath);
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
            afisate = true;
        }
        private void ShowMovieDetails(Film film)
        {
            Form2 movieDetailsForm = new Form2();
            movieDetailsForm.SetMovieDetails(film);
            movieDetailsForm.Text = film.Title;
            movieDetailsForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 Detalii = new Form3();
            Detalii.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 watchlist = new Form4();
            watchlist.Text = "Watchlist";
           
            watchlist.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            afisate = false;
            if (afisate == false)
            {
                bagapoze();

            }
        }
        bool extend = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (extend == false)
            {
                flowLayoutPanelVolum.Height = 113;
                extend = true;
            }
            else
            {
                flowLayoutPanelVolum.Height = 36;
                extend = false;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            muzicavolum(trackBar1.Value/10f);
        }
        private void muzicavolum(float vol)
        {
            muzica.Volume = vol;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            afisate = false;
            bagaThriller();
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            afisate = false;
            bagaHorror();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            afisate = false;
            bagaActiune();
            
        }
        private void bagaThriller()
        {
            foreach (var film in filme)
            {
                if (film.Category == "Thriller")
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = 200;
                    pictureBox.Height = 300;
                    pictureBox.Margin = new Padding(10);
                    pictureBox.Image = Image.FromFile(film.ImagePath);
                    pictureBox.Click += (sender, e) => ShowMovieDetails(film);
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }
            }
        }
        private void bagaHorror()
        {
            foreach (var film in filme)
            {
                if (film.Category == "Horror")
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = 200;
                    pictureBox.Height = 300;
                    pictureBox.Margin = new Padding(10);
                    pictureBox.Image = Image.FromFile(film.ImagePath);
                    pictureBox.Click += (sender, e) => ShowMovieDetails(film);
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }
            }
        }
        private void bagaActiune()
        {
            foreach (var film in filme)
            {
                if (film.Category == "Action")
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Width = 200;
                    pictureBox.Height = 300;
                    pictureBox.Margin = new Padding(10);
                    pictureBox.Image = Image.FromFile(film.ImagePath);
                    pictureBox.Click += (sender, e) => ShowMovieDetails(film);
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }
            }
        }
        bool intins;
        private void button6_Click(object sender, EventArgs e)
        {
            
            if (intins == false)
            {
                flowLayoutPanel3.Height = 172;
                intins = true;
            }
            else
            {
                flowLayoutPanel3.Height = 36;
                intins = false;
            }
        }
    }
}
