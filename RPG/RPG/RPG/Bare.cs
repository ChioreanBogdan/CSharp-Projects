using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using WMPLib;

namespace RPG
{
    class Bare //Clasa folosita pt operatiile cu barele de viata de energie a personajelor si inamicilor
    {
        public static Bitmap Umple_bara_viata(int l,int h,int vmax,int vc)
        {
            Bitmap bmp;
            Graphics g;

            //creare bitmap
            bmp = new Bitmap(l, h); //vp1_latime=405

            //grafic
            g = Graphics.FromImage(bmp);
            g.Clear(Color.LightGray);
            g.FillRectangle(Brushes.GreenYellow, new Rectangle(0, 0, l, h));
            g.DrawString(vc+"/"+ vmax, new Font("Blackadder ITC", h-4), Brushes.Black, new PointF(170, -4));
            return bmp;
        }

        public static Bitmap Umple_bara_energie(int l, int h,int emax,int ec)
        {
            Bitmap bmp;
            Graphics g;

            //creare bitmap
            bmp = new Bitmap(l, h); //l=405 h=18

            //grafic
            g = Graphics.FromImage(bmp);
            g.Clear(Color.LightGray);
            g.FillRectangle(Brushes.BlueViolet, new Rectangle(0, 0, l, h));
            g.DrawString(ec + "/" + emax, new Font("Blackadder ITC", h - 4), Brushes.Black, new PointF(170, -4));
            return bmp;
        }

        public static Bitmap Update_bara_viata(int l, int h, int vmax, int vc) //updateaza bara de viata in functie de viata curenta a personajului/inamicului
        {
            Bitmap bmp;
            Graphics g;
            int updt; //scade unitati din bara de viata corelat cu cata viata scade (ex la 15 puncte din 100 viata scad 61 de pixeli din 405 pixeli cat are bara de viata)

            //creare bitmap
            bmp = new Bitmap(l, h); //vp1_latime=405

            updt = (l*vc)/vmax; //regula de 3 simpla pt a transporta punctele de viata a inamicului/personajului in pixeli pt bara de viata
            //grafic
            g = Graphics.FromImage(bmp);
            g.Clear(Color.LightGray);
            g.FillRectangle(Brushes.GreenYellow, new Rectangle(0, 0, l, h));
            if (vc >= 0)
            {
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, l - updt, h));
                g.DrawString(vc + "/" + vmax, new Font("Blackadder ITC", h - 4), Brushes.Black, new PointF(170, -4));
            }
            else
            {
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, l - updt, h));
                g.DrawString("0/" + vmax, new Font("Blackadder ITC", h - 4), Brushes.Black, new PointF(170, -4));
            }
            return bmp;
        }

        public static Bitmap Update_bara_energie(int l, int h, int emax, int ec) //updateaza bara de energie in functie de energia curenta a personajului/inamicului
        {
            Bitmap bmp;
            Graphics g;
            int updt; //scade unitati din bara de energie corelat cu cata energie scade (ex la 15 puncte din 100 energie scad 61 de pixeli din 405 pixeli cat are bara de energie)

            //creare bitmap
            bmp = new Bitmap(l, h); //ep1_latime=405

            updt = (l * ec) / emax; //regula de 3 simpla pt a transporta punctele de energie a inamicului/personajului in pixeli pt bara de energie
            //grafic
            g = Graphics.FromImage(bmp);
            g.Clear(Color.LightGray);
            g.FillRectangle(Brushes.BlueViolet, new Rectangle(0, 0, l, h));
            if (ec >= 0)
            {
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, l - updt, h));
                g.DrawString(ec + "/" + emax, new Font("Blackadder ITC", h - 4), Brushes.Black, new PointF(170, -4));
            }
            else
            {
                g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, l - updt, h));
                g.DrawString("0/" + emax, new Font("Blackadder ITC", h - 4), Brushes.Black, new PointF(170, -4));
            }
            return bmp;
        }

    }
}
