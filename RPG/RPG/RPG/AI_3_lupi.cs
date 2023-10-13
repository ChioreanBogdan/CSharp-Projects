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
    class AI_3_lupi //comportamentul de lupta pentru inamici: 3 lupi
    {
        public static int urlet_lup1_act = 0; public static int urlet_lup2_act = 0; public static int urlet_lup3_act = 0; //verifica daca urletele lupilor sunt activate

        public static void Actiune_lup1() //lupul 1 urla si scade atacurile fizice ale tuturor personajelor cu 5 puncte
        {
            if (Lupta.vc_i1 > 0 && Lupta.paraliz_i1 == 0) //verific daca lupul e in viata si nu e paralizat
            {
                if (Lupta.ec_i1 >= 5 && (Lupta.vc_i2 > 0 || Lupta.vc_i3 > 0)) //daca mai are energie sau ceilalti lupi sunt in viata lupul 1 urla
                {
                    urlet_lup1_act = 1;
                    Lupta.ec_i1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_i1,5);
                }
                if (Lupta.ec_i1 <= 5 || (Lupta.vc_i2 <= 0 && Lupta.vc_i3 <= 0))
                {
                    urlet_lup1_act = 0;

                    if (Lupta.vc_p1 > 0) //verific daca personajul 2 e in viata
                    {
                        Lupta.vc_p1 = Efecte_ofensive.Muscatura(1, Lupta.vc_p1, 10,Lupta.atc_cresc_i1_fiz,Lupta.atc_scad_i1_fiz, Lupta.reduc_mem_p1, 115, 151);
                        if (Efecte_ofensive.provoaca_rana == 1) Efecte_ofensive.p1_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                    }
                    else if (Lupta.vc_p2 > 0) //verific daca personajul 3 e in viata
                    {
                        Lupta.vc_p2 = Efecte_ofensive.Muscatura(2, Lupta.vc_p2, 10, Lupta.atc_cresc_i1_fiz, Lupta.atc_scad_i1_fiz, Lupta.reduc_mem_p2, 115, 320);
                        if (Efecte_ofensive.provoaca_rana == 1) Efecte_ofensive.p2_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                    }
                    else
                    {
                        Lupta.vc_p3 = Efecte_ofensive.Muscatura(3, Lupta.vc_p3, 10, Lupta.atc_cresc_i1_fiz, Lupta.atc_scad_i1_fiz, Lupta.reduc_mem_p3, 115, 493);
                        if (Efecte_ofensive.provoaca_rana == 1) Efecte_ofensive.p3_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                    }
                }
            } else urlet_lup1_act = 0; //daca lupul are 0 viata sau e paralizat nu poate activa urletul in tura urmatoare
        }

       public static void Actiune_lup2() //lupul 2 ataca personajul din slot-ul 2
        {
            if (Lupta.vc_i2>0 && Lupta.paraliz_i2== 0) //verific daca lupul e in viata si nu e paralizat
            {
                if (Lupta.vc_p2 > 0) //verific daca personajul 2 e in viata
                {
                    Lupta.vc_p2 = Efecte_ofensive.Muscatura(2,Lupta.vc_p2, 10,Lupta.atc_cresc_i2_fiz, Lupta.atc_scad_i2_fiz, Lupta.reduc_mem_p2, 115, 320);
                    if (Efecte_ofensive.provoaca_rana == 1 && Efecte_defensive.p2_regen==0) Efecte_ofensive.p2_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii si nu e sub efectul "Regenerarii"
                }
                else if (Lupta.vc_p3 > 0) //verific daca personajul 3 e in viata
                {
                    Lupta.vc_p3 = Efecte_ofensive.Muscatura(3,Lupta.vc_p3, 10, Lupta.atc_cresc_i2_fiz, Lupta.atc_scad_i2_fiz, Lupta.reduc_mem_p3, 115, 493);
                    if (Efecte_ofensive.provoaca_rana == 1 && Efecte_defensive.p3_regen == 0) Efecte_ofensive.p3_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                }
                else
                {
                    Lupta.vc_p1 = Efecte_ofensive.Muscatura(1,Lupta.vc_p1, 10, Lupta.atc_cresc_i2_fiz, Lupta.atc_scad_i2_fiz, Lupta.reduc_mem_p1, 115, 151);
                    if (Efecte_ofensive.provoaca_rana == 1 && Efecte_defensive.p1_regen == 0) Efecte_ofensive.p1_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                }
            }
        }

        public static void Actiune_lup3() //lupul 3 ataca personajul din slot-ul 3
        {
            if (Lupta.vc_i3 > 0 && Lupta.paraliz_i3== 0) //verific daca lupul e in viata si nu e paralizat
            {
                if (Lupta.vc_p3 > 0) //verific daca personajul 3 e in viata
                {
                    Lupta.vc_p3 = Efecte_ofensive.Muscatura(3,Lupta.vc_p3, 10, Lupta.atc_cresc_i3_fiz, Lupta.atc_scad_i3_fiz, Lupta.reduc_mem_p3, 115, 493);
                    if (Efecte_ofensive.provoaca_rana==1) Efecte_ofensive.p3_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                }
                else if (Lupta.vc_p2 > 0) //verific daca personajul 2 e in viata
                {
                    Lupta.vc_p2 = Efecte_ofensive.Muscatura(2,Lupta.vc_p2, 10, Lupta.atc_cresc_i3_fiz, Lupta.atc_scad_i3_fiz, Lupta.reduc_mem_p2, 115, 320);
                    if (Efecte_ofensive.provoaca_rana == 1) Efecte_ofensive.p2_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                }
                else if (Lupta.vc_p1 > 0) //verific daca personajul 2 e in viata
                {
                    Lupta.vc_p1 = Efecte_ofensive.Muscatura(1,Lupta.vc_p1,10, Lupta.atc_cresc_i3_fiz, Lupta.atc_scad_i3_fiz,Lupta.reduc_mem_p1, 115, 151);
                    if (Efecte_ofensive.provoaca_rana == 1) Efecte_ofensive.p1_sang = 1; //verificam daca personajul a fost ranit in urma muscaturii
                }
            }
        }
    }
}
