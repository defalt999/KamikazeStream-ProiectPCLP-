using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace KamikazeStream
{
    public partial class Form4 : Form
    {
        public List<Film> listaPrimita = new List<Film>();

        public Form4()
        {
            InitializeComponent();
            arataWatchListu();
        }


        private void arataWatchListu()
        {
            if (watchlist.listaVizionare.Count == 0)
            {
                RichTextBox text = new RichTextBox();
                text.Width = 1400;
                text.Height = 600;
                text.Font = new Font("Arial", 60);
                text.Multiline = true;
                text.Text = "Lista este goala";
                text.ReadOnly = true;
                //stackoverflow
                text.SelectAll();
                text.SelectionAlignment = HorizontalAlignment.Center;
                text.DeselectAll();
                //===========================


                flowLayoutPanel1.Controls.Add(text);               
            }
            
            foreach (var film in watchlist.listaVizionare)
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
        private void ShowMovieDetails(Film film)
        {
            Form2 movieDetailsForm = new Form2();
            movieDetailsForm.SetMovieDetails(film);
            movieDetailsForm.Text = film.Title;
            movieDetailsForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            arataWatchListu();
        }
    }
}
