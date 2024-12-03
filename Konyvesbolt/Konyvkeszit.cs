using System;
using System.Collections.Generic;

namespace Konyvesbolt
{
    public static class KonyvKeszit
    {
        // Egyszerű könyvgyártó függvény
        public static List<Konyv> ElojallitKonyvek(int darabszam, Random veletlen)
        {
            string[] magyarCimek = { "Rejtett kincsek", "A magyar történelem", "Csendes éj" };
            string[] angolCimek = { "Hidden Gems", "The History of Hungary", "Silent Night" };
            string[] szerzok = { "Kovács Béla", "Anna Müller", "John Smith" };

            var konyvek = new List<Konyv>();

            while (konyvek.Count < darabszam)
            {
                string nyelv = veletlen.NextDouble() < 0.8 ? "Magyar" : "Angol";
                string cim = nyelv == "Magyar" ? magyarCimek[veletlen.Next(magyarCimek.Length)] : angolCimek[veletlen.Next(angolCimek.Length)];
                int ar = veletlen.Next(10, 101) * 100;
                int keszlet = veletlen.NextDouble() < 0.3 ? 0 : veletlen.Next(5, 11);
                string isbn = ISBNGeneralas(veletlen);

                var szerzokLista = new List<string> { szerzok[veletlen.Next(szerzok.Length)] };

                konyvek.Add(new Konyv(isbn, cim, nyelv, ar, keszlet, szerzokLista));
            }

            return konyvek;
        }

        private static string ISBNGeneralas(Random rng)
        {
            return string.Concat(Enumerable.Range(0, 10).Select(_ => rng.Next(0, 10).ToString()));
        }
    }
}