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
     class timespan
    {
        int ora { get; set; }
        int minute { get; set; }
        int secunde { get; set; }
    }
     class film{
         string nume { get; set; }
        string regizor { get; set; }
        string categorie { get; set; }
        int anLansare { get; set; }
        string rating { get; set; }
        timespan durata { get; set; }
        string imaginePath { get; set; }

    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
