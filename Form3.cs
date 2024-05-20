using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamikazeStream
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = "!Proiect! Realizat de Bratosin Denis-Catalin";
            richTextBox1.Text = "Va rog un 5 , si un 5 pt indian sa fie bine";
            textBox1.ReadOnly=true;
            richTextBox1.ReadOnly = true;
        }
    }
}
