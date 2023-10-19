using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PİSTİ_OYUNU
{
    public class Kart
    {
        private string tip;
        public string Tip
        {
            get { return tip; }
        }

        private string numara;
        public string Numara
        {
            get { return numara; }
        }


        public int Puan
        {
            get
            {
                if (numara == "As" || numara == "Vale")
                {
                    return 1;
                }


                else if (numara == "2" && tip == "Sinek")
                {

                    return 2;
                }

                else if (numara == "10" && tip == "Diamonds") //Karo 10
                {
                    return 3;
                }
                else
                {
                    return 0;
                }

            }
        }



        public Kart(string tip, string numara)
        {
            this.tip = tip;
            this.numara = numara;
        }



        public override string ToString()
        {
            return "[" + tip + " " + numara + " (" + Puan + ")]";
        }



    }
}
