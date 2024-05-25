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
        
        private Form4 form4;
        public Form2()
        {
            InitializeComponent();
            form4 = new Form4();

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
            if (!watchlist.listaVizionare.Contains(movie))
            {
                watchlist.listaVizionare.Add(movie);
                MessageBox.Show("Filmul adaugat in lista");
            }
            else
            {
                MessageBox.Show("Filmul este deja in lista");
            }
            
        }
        public void stergeWatchList(Film movie)
        {
            if (watchlist.listaVizionare.Contains(movie))
            {
                watchlist.listaVizionare.Remove(movie);
                MessageBox.Show("Filmul sters din lista");
            }
            else
            {
                MessageBox.Show("Filmul nu este in lista");
            }
        }       
    }
}

