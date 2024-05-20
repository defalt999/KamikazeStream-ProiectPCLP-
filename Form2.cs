using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Text;
namespace KamikazeStream
{
    public partial class Form2 : Form
    {
        

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





        }

    }
}

