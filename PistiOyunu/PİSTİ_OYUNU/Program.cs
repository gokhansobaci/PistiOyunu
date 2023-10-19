using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PİSTİ_OYUNU
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**** Pişti Oyununa Hoşgeldiniz **** ");
            Console.WriteLine();

            Masa masa = new Masa(4);
            masa.OtoOyna();
            Console.WriteLine(masa);
            Console.ReadLine();
        }
    }
}
