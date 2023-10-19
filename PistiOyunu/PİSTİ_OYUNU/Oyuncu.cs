using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PİSTİ_OYUNU
{
    public class Oyuncu
    {
        public string Isim { get; set; }
        public List<Kart> El { get; set; }
        public List<Kart> Kazanılan { get; set; }
        public int pisti_sayisi;
        public bool MaksKart { get; set; }

        public int Puan
        {
            get
            {

                int puan = 0;
                foreach (var item in Kazanılan)
                {
                    puan += item.Puan;
                }

                return pisti_sayisi * 10 + (MaksKart ? 3 : 0) + puan;
            }
        }

        public void PistiYap()
        {
            pisti_sayisi++;
        }

        public void MaxCardGecis()
        {
            MaksKart = !MaksKart;
        }


        public Oyuncu(string name)
        {
            Isim = name;
            El = new List<Kart>();
            Kazanılan = new List<Kart>();
            pisti_sayisi = 0;
            MaksKart = false;
        }

        private Random rand = new Random();
        public Kart Birak(int index = -1)
        {
            if (index < 0 || index > El.Count - 1)
            {
                index = rand.Next(El.Count);
            }
            Kart selected = El[index];
            El.RemoveAt(index);
            return selected;
        }


        public void Topla(List<Kart> havuz)
        {
            Kazanılan.AddRange(havuz);
        }

        public void EliAl(List<Kart> kartlar)
        {
            El.AddRange(kartlar);
        }

        public override string ToString()
        {
            return Isim + " (" + Puan + "):\n" +
                    "\tEarnings (" + Kazanılan.Count + "): " + string.Join(", ", Kazanılan) + "\n" +
                    "\tHand (" + El.Count + "): " + string.Join(", ", El);
        }


    }
}
