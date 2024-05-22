using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Text;
using System.Collections.Generic;

namespace KamikazeStream
{
    public partial class Form2 : Form
    {
        private List<Film> listaVizionare;

        public Form2()
        {
            InitializeComponent();
            
        }
       



        public void SetMovieDetails(Film movie)
        {
            textBox1.Text = movie.Title;
            textBox3.Text = "Directed by: " + movie.Director;
            richTextBox1.Text = movie.Description;
            pictureBox1.Image = Image.FromFile(movie.ImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            richTextBox1.ReadOnly = true;
            button2.Click += (sender, e) => adaugaWatchList(movie);
            button1.Click += (sender, e) => stergeWatchList(movie);
        }

        public void adaugaWatchList(Film movie)
        {
            listaVizionare.Add(movie);
        }
        public void stergeWatchList(Film movie)
        {
            MessageBox.Show("OK!");
        }

    }
}

