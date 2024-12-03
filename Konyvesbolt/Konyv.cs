using System;
using System.Collections.Generic;

namespace Konyvesbolt
{
    public class Konyv
    {
        public string ISBN { get; private set; }
        public string Cim { get; private set; }
        public string Nyelv { get; private set; }
        public int Ar { get; private set; }
        public int Keszlet { get; set; }
        public List<string> Szerzok { get; private set; }

        public Konyv(string isbn, string cim, string nyelv, int ar, int keszlet, List<string> szerzok)
        {
            ISBN = isbn;
            Cim = cim;
            Nyelv = nyelv;
            Ar = ar;
            Keszlet = keszlet;
            Szerzok = szerzok;
        }

        public override string ToString()
        {
            string szerzokSzoveg = Szerzok.Count == 1 ? "Szerző:" : "Szerzők:";
            string keszletSzoveg = Keszlet > 0 ? $"{Keszlet} db" : "Beszerzés alatt";
            return $"{szerzokSzoveg} {string.Join(", ", Szerzok)}\n" +
                   $"Cím: {Cim}\n" +
                   $"Nyelv: {Nyelv}\n" +
                   $"Ár: {Ar} Ft\n" +
                   $"Készlet: {keszletSzoveg}";
        }
    }
}