using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaYarisiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int kazanilanPuan = 0;
        int yolHizi = 20;
        int arabaHizi = 5; //benim araba hızım

        bool solYon = false;
        bool sagYon = false;

        int digerArabaHİZİ = 5;

        Random rnd = new Random(); 

        public void oyunuBaslat()
        {
            btn_oyunuBaslat.Enabled = false;
            carpma.Visible = false;
            arabaHizi = 5;
            digerArabaHİZİ = 5;
            kazanilanPuan = 0;

            //arabanın koordinati : kendi arabam.

            bizimaraba.Left = 160;
            bizimaraba.Top = 300;

            araba1.Left = 30;
            bizimaraba.Top = 50;

            araba2.Left = 320;
            araba2.Top = 50;
            solYon = false;
            sagYon = false;

            timer1.Start();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            oyunuBaslat();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanilanPuan++;
            lbl_puan.Text = kazanilanPuan.ToString();

            yol.Top += yolHizi;

            if (yol.Top>400)
            {
                yol.Top = -100;
            }
            if (solYon)
            {
                bizimaraba.Left -= arabaHizi;
            }
            if (sagYon)
            {
                bizimaraba.Left += arabaHizi;
            }
            if (bizimaraba.Left<1)
            {
                solYon = false;
            }
            else if (bizimaraba.Left+bizimaraba.Width>510)
            {
                sagYon = false;
            }

            araba1.Top += arabaHizi;
            araba2.Top += arabaHizi;

            if (araba1.Top>panel1.Height)
            {
                arabaDegistir();
                araba1.Left = rnd.Next(20, 50);
                araba1.Top = rnd.Next(40, 100) * -1;
            }
            if (araba2.Top>panel1.Height)
            {
                araba2Degistir();
                araba2.Left = rnd.Next(20, 50);
                araba2.Top = rnd.Next(40, 100) * -1;
            }


            if (bizimaraba.Bounds.IntersectsWith(araba2.Bounds)|| bizimaraba.Bounds.IntersectsWith(araba2.Bounds))
            {
                oyunBitti();
            }
        }

        private void araba2Degistir()
        {
            throw new NotImplementedException();
        }

        private void oyunBitti()
        {
            throw new NotImplementedException();
        }

        private void arabaDegistir()
        {
            int sıra = rnd.Next(1, 7);
            switch (sıra)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba1;
                    break;
                case 2:
                    araba1.Image = Properties.Resources.araba2;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba7;
                    break;
                default:
                    break;
            }
        }
    }
}
