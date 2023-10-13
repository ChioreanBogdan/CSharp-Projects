using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using WMPLib;

namespace RPG
{

    class Audio_player
    {
        public static WMPLib.WindowsMediaPlayer muz_player = new WMPLib.WindowsMediaPlayer(); //playerul pt muzica din joc
        public static WMPLib.WindowsMediaPlayer sun_player = new WMPLib.WindowsMediaPlayer(); //playerul pt suntele din joc

        public static void playm() //functie pt a repeta o melodie in bucla
        {
            muz_player.URL = @"C:\postuniv\C#\RPG\RPG\RPG\Resources\padure.mp3";
            muz_player.settings.autoStart = true;
            muz_player.settings.setMode("loop", true); //pt ca melodia sa se repete
            muz_player.settings.volume = 50;
        }

        public static void plays()
        {
            sun_player.settings.volume = 70; //vrem ca volumul sunetelor sa fie un pic mai mare decat cel al muzicii,initial
        }

        public static void sunet_zar() //efect sonor sunet zar
        {
            sun_player.controls.stop(); //oprim efectul sonor care eventual se derula inainte
            sun_player.URL = @"C:\postuniv\C#\RPG\RPG\RPG\Resources\zar.mp3";
            sun_player.controls.play();
        }

        public static void sunet_click() //efect sonor sunet click
        {
            sun_player.controls.stop(); //oprim efectul sonor care eventual se derula inainte
            sun_player.URL = @"C:\postuniv\C#\RPG\RPG\RPG\Resources\click.wav";
            sun_player.controls.play();
        }
    }
}
