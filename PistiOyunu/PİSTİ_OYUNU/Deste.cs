using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PİSTİ_OYUNU
{
    public class Deste
    {
        public List<Kart> Kartlar { get; set; }
        public Deste(int deste_sayisi = 1)
        {
            // Tanımladımız Kart tipindeki listeye yeni bir alan(new liyoruz) açıyoruz.
            this.Kartlar = new List<Kart>();
            //Kartın tipini ve değerini tanımlıyoruz.
            string[] tipler = { "Sinek", "Karo", "Kupa", "Maça" };
            string[] numaralar = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Vale", "Kız", "Papaz" };
            for (int i = 0; i < deste_sayisi; i++)
            {
                foreach (var tip in tipler)
                {
                    foreach (var numara in numaralar)
                    {
                        Kart kart = new Kart(tip, numara);
                        this.Kartlar.Add(kart);
                    }
                }
            }

            this.shuffle();
        }

        //Kartları karıştırmak için böyle bir fonksiyon yazdım.
        private void shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < this.Kartlar.Count * 2; i++)
            {
                int destenin_yarisi = this.Kartlar.Count / 2;
                int ilk_indeks = rand.Next(0, destenin_yarisi);
                int ikinci_indeks = rand.Next(0, destenin_yarisi) + destenin_yarisi;

                //Burada desteleri yer değiştiriyoruz
                Kart temp = this.Kartlar[ilk_indeks];
                this.Kartlar[ilk_indeks] = this.Kartlar[ikinci_indeks];
                this.Kartlar[ikinci_indeks] = temp;




            }
        }

        public List<Kart> KartlarıGetir(int kart_sayisi = 1)
        {
            //Verilecek kartları seçtik 
            List<Kart> selected = this.Kartlar.GetRange(0, kart_sayisi);
            //Verilen Kartları desteden çıkardık.
            this.Kartlar.RemoveRange(0, kart_sayisi);
            //seçilen kartları dönüyoruz.
            return selected;


        }

        public override string ToString()
        {
            return "Deste (" + Kartlar.Count + "): " + string.Join(", ", Kartlar);
        }

    }
}
