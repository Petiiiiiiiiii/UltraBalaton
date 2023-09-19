using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace CA20230919
{
    class Program
    {
        static void Main()
        {
            var versenyzok = new List<Versenyzo>();

            using var sr = new StreamReader(
                path: @"..\..\..\src\ub2017egyeni.txt",
                encoding: Encoding.UTF8);

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
                versenyzok.Add(new Versenyzo(sr.ReadLine()));

            Console.WriteLine($"3.feladat: egyeni indulók száma: {versenyzok.Count}");

            var f4 = versenyzok.Count(v => !v.Kategoria && v.Tavszazalek == 100);
            Console.WriteLine($"4. feladat: teljes tavot teljesítő nők száma: {f4} fő");

            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            string nev = Console.ReadLine().ToLower();

            Versenyzo f5 = versenyzok.FirstOrDefault(v => v.Nev.ToLower() == nev);
            if (f5 != null)
                Console.WriteLine("\tIndult egyeniben a sportolo? NEM");
            else
                Console.WriteLine("\tIndult egyeniben a sportolo? IGEN");
                Console.WriteLine($"\tTeljesitette a telejes távot: " +
                    $"{(f5.Tavszazalek == 100 ? "IGEN" : "NEM")}");

            var f7 = versenyzok
                .Where(v => v.Kategoria && v.Tavszazalek == 100)
                .Average(v => v.IdoOraban);

            Console.WriteLine($"7. feladat: férfiak átlagideje: {f7:0.00} óra");

            var f8n = versenyzok
                .Where(v => !v.Kategoria && v.Tavszazalek == 100)
                .OrderByDescending(v => v.Versenyido)
                .First();

            var f8f = versenyzok
                .Where(v => v.Kategoria && v.Tavszazalek == 100)
                .OrderByDescending(v => v.Versenyido)
                .First();

            Console.WriteLine("8.feladat verseny győztesei:");
            Console.WriteLine($"Nők : {f8n.Nev}");
            Console.WriteLine($"Férfiak : {f8f.Nev}");
            
            Console.ReadKey();
        }
    }
}
