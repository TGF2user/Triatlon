using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Versenyzo
    {
        public string Nev;
        public int UI = 0, KI = 0, FI = 0;

        public Versenyzo(string Nev, int UI, int KI, int FI)
        {
            this.Nev = Nev;
            this.UI = UI;
            this.KI = KI;
            this.FI = FI;
        }

        public Versenyzo()
        {
 
        }

        public int getVersenyIdo() //Visszaadja az egész versenyidőt másodpercekben
        {
            return UI + KI + FI;
        }

        public double getAtSebUsz() //Visszaadja az átlagsebességet az úszásnál
        {
            return Math.Round((1.5d / (UI / 3600d)),2);
        }

        public double getAtSebKer() //Visszaadja az átlagsebességet a kerékpározásnál
        {
            return Math.Round((40 / (KI / 3600d)), 2);
        }

        public double getAtSebFut() //Visszaadja az átlagsebességet a futásnál
        {
            return Math.Round((10/ (FI / 3600d)), 2);
        }

        public string getIdoForm(int Idő) //Másodpercekből egz Óra:Perc:Másodperc formátumot ad vissza
        {
            string Ki = "";
            //int ido = UI + KI + FI;
            string Ora = Math.Floor(Idő/3600d).ToString();
            string Perc = Math.Floor((Idő % 3600d)/60d).ToString();
            string Másodperc = (Idő % 60).ToString();

            if (Ora.Length != 2) Ora = "0" + Ora;
            if (Perc.Length != 2) Perc = "0" + Perc;
            if (Másodperc.Length != 2) Másodperc = "0" + Másodperc;

            Ki = Ora + ":" + Perc + ":" + Másodperc;

            return Ki;
        }

    }
}
