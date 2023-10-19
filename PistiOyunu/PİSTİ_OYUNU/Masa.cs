using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PİSTİ_OYUNU
{
    public class Masa
    {

        public Oyuncu[] Oyuncular;
        public List<Kart> Havuz;
        public Deste MevcutDeste;
        public Masa(int oyuncu_sayisi = 1)
        {
            Oyuncular = new Oyuncu[oyuncu_sayisi];
            for (int i = 0; i < oyuncu_sayisi; i++)
            {
                Oyuncular[i] = new Oyuncu("Player" + (i + 1));

            }

            Havuz = new List<Kart>();
            MevcutDeste = new Deste();
        }


        public void ElBeraberi()
        {
            if (MevcutDeste.Kartlar.Count == 52)
            {

                //İlk 4 kartı yere açıyoru<
                Havuz = MevcutDeste.KartlarıGetir(4);
            }

            foreach (var oyuncu in Oyuncular)
            {
                oyuncu.EliAl(MevcutDeste.KartlarıGetir(4));
            }
        }

        public void OtoOyna()
        {
            while (MevcutDeste.Kartlar.Count > 0)
            {
                ElBeraberi();
                for (int i = 0; i < 4; i++)
                {
                    foreach (var oyuncu in Oyuncular)
                    {
                        Kart birakildi = oyuncu.Birak();


                        switch (KuralKontrol(birakildi))
                        {
                            case KuralDurumu.None:
                                Havuz.Add(birakildi);
                                break;
                            case KuralDurumu.Normal:
                                Havuz.Add(birakildi);
                                oyuncu.Topla(Havuz);
                                Havuz.Clear();
                                break;

                            case KuralDurumu.Pisti:
                                Havuz.Add(birakildi);
                                oyuncu.Topla(Havuz);
                                oyuncu.PistiYap();
                                Havuz.Clear();
                                break;

                        }
                    }
                }

            }
        }


        private KuralDurumu KuralKontrol(Kart birakildi)
        {
            if (Havuz.Count > 0)
            {
                Kart top = Havuz[Havuz.Count - 1];
                if (Havuz.Count == 1 && birakildi.Numara == top.Numara)
                {
                    //Pişti kontrolü (Ödev): Oyuncunun pişti sayısını bir arttırın.
                    return KuralDurumu.Pisti;
                }
                else if (birakildi.Numara == top.Numara)
                {
                    return KuralDurumu.Normal;
                }
                else if (birakildi.Numara == "Vale")
                {
                    return KuralDurumu.Normal;
                }
            }
            return KuralDurumu.None;
        }

        public override string ToString()
        {
            string deste = MevcutDeste.ToString();

            string oyuncular = string.Join("\n\n", Oyuncular.ToList());
            string havuz = "Pool (" + Havuz.Count + "): " + string.Join(", ", Havuz);
            return deste + "\n\n\n" + havuz + "\n\n\n" + oyuncular;
        }
    }
}
