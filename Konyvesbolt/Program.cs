using System;
using System.Collections.Generic;
using System.Linq;

namespace Konyvesbolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Véletlenszerű generátor inicializálása
            Random veletlen = new Random();

            // 15 véletlenszerű könyv létrehozása
            List<Konyv> konyvek = KonyvKeszit.ElojallitKonyvek(15, veletlen);

            // Kiindulási adatok összegyűjtése
            int kezdetiKeszlet = konyvek.Sum(k => k.Keszlet);
            int teljesBevetel = 0;
            int elfogyottKonyvek = 0;

            // 100 vásárlási folyamat szimulációja
            for (int i = 0; i < 100; i++)
            {
                if (!konyvek.Any()) break; // Ha nincs több könyv, kilépünk

                Konyv valasztottKonyv = konyvek[veletlen.Next(konyvek.Count)];

                if (valasztottKonyv.Keszlet > 0)
                {
                    // Vásárlás
                    valasztottKonyv.Keszlet--;
                    teljesBevetel += valasztottKonyv.Ar;
                }
                else if (veletlen.NextDouble() < 0.5)
                {
                    // Új készlet érkezik
                    valasztottKonyv.Keszlet += veletlen.Next(1, 11);
                }
                else
                {
                    // Elfogyott a nagykerből is
                    konyvek.Remove(valasztottKonyv);
                    elfogyottKonyvek++;
                }
            }

            // Végső készlet számítása
            int aktualisKeszlet = konyvek.Sum(k => k.Keszlet);

            // Eredmények kiírása
            Console.WriteLine($"Összes bevétel: {teljesBevetel} Ft");
            Console.WriteLine($"Elfogyott könyvek száma: {elfogyottKonyvek}");
            Console.WriteLine($"Készletváltozás: Kezdeti: {kezdetiKeszlet}, Jelenlegi: {aktualisKeszlet}, Különbség: {aktualisKeszlet - kezdetiKeszlet}");
        }
    }
}

