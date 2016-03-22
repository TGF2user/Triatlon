using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program
{
    class Program
    {
        public static void Rendez(List<Versenyzo> be)
        {
            Versenyzo Csere = new Versenyzo(); //Létrehoz egy ideiglenes változót

            #region Sorbarendezés
            for (int i = 0; i < be.Count-1; i++)
            {
                int index = i;
                int ertek = be[i].getVersenyIdo();
                for (int j = i + 1; j < be.Count; j++)
                {
                    if (be[j].getVersenyIdo() < ertek) 
                    {
                        ertek = be[j].getVersenyIdo();
                        index = j; 
                    }
                }
                Csere = be[i];
                be[i] = be[index];
                be[index] = Csere;
            }
            #endregion
        }

        static void Main(string[] args)
        {
            List<Versenyzo> Versenyzok = new List<Versenyzo>();

            using (StreamReader FáljOlvasó = new StreamReader("TRIATLON.BE", Encoding.UTF8))
            {
                
                while (!FáljOlvasó.EndOfStream)
                {
                    //Ideiglenes változóba beteszi az értékeket, majd beteszi a listába
                    Versenyzo Ideiglenes = new Versenyzo();
                    Ideiglenes.Nev = FáljOlvasó.ReadLine();
                    Ideiglenes.UI = int.Parse(FáljOlvasó.ReadLine());
                    Ideiglenes.KI = int.Parse(FáljOlvasó.ReadLine());
                    Ideiglenes.FI = int.Parse(FáljOlvasó.ReadLine());

                    Versenyzok.Add(Ideiglenes);
                }
            }

            Rendez(Versenyzok); //Rendez versenyidő szerint

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}",Versenyzok[i].Nev); //Kiírja a top 3-at versenyidő szerint
            }

            Console.WriteLine();
            //kiírja a képernyőre az úszási, kerékpározási, futási átlagsebességet
            Console.WriteLine("{0}\nÚszás átlagsebesség: {1} km/h\nKerékpár átlagsebesség: {2} km/h\nFutás átlagsebesség: {3} km/h", Versenyzok[0].Nev, Versenyzok[0].getAtSebUsz(),Versenyzok[0].getAtSebKer(),Versenyzok[0].getAtSebFut());

            using (StreamWriter FáljÍró = new StreamWriter("TRIATLON.KI")) //TRIATLON.KI-fáljba írja ki a formázott eredményeket
            {
                for (int i = 0; i < Versenyzok.Count; i++)
                {
                    FáljÍró.WriteLine(Versenyzok[i].Nev +" "+ Versenyzok[i].getIdoForm(Versenyzok[i].getVersenyIdo()));
                }
            }

            using (StreamWriter FáljÍró = new StreamWriter("RESZER.KI")) //TRIATLON.KI-fáljba írja ki a formázott részeredményeket (Úszás, Kerékpározás, Futás)
            {
                #region Fáljba írás rendezéssel
                int LKI = 0;

                for (int i = 1; i < Versenyzok.Count; i++)
                {
                    if (Versenyzok[LKI].UI > Versenyzok[i].UI)
                    {
                        LKI = i;
                    }
                }

                FáljÍró.WriteLine(Versenyzok[LKI].Nev + " " + Versenyzok[LKI].getIdoForm(Versenyzok[LKI].UI));

                LKI = 0;
                for (int i = 1; i < Versenyzok.Count; i++)
                {
                    if (Versenyzok[LKI].KI > Versenyzok[i].KI)
                    {
                        LKI = i;
                    }
                }

                FáljÍró.WriteLine(Versenyzok[LKI].Nev + " " + Versenyzok[LKI].getIdoForm(Versenyzok[LKI].KI));

                LKI = 0;
                for (int i = 1; i < Versenyzok.Count; i++)
                {
                    if (Versenyzok[LKI].FI > Versenyzok[i].FI)
                    {
                        LKI = i;
                    }
                }

                FáljÍró.WriteLine(Versenyzok[LKI].Nev + " " + Versenyzok[LKI].getIdoForm(Versenyzok[LKI].FI));
                #endregion
            }

            Console.ReadKey();//Program lefutása után vár egy gomblenyomásra
        }
    }
}
