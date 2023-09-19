using System;
using System.Collections.Generic;
using System.Text;

namespace CA20230919
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public string Rajtszam { get; set; }
        public bool Kategoria { get; set; }
        public TimeSpan Versenyido { get; set; }
        public int Tavszazalek { get; set; }

        public double IdoOraban => Versenyido.TotalHours;

        public Versenyzo(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Rajtszam = v[1];
            Kategoria = v[2] == "Ferfi";
            var ido = v[3].Split(':');
            Versenyido = new TimeSpan(
                hours: int.Parse(ido[0]),
                minutes: int.Parse(ido[1]),
                seconds: int.Parse(ido[2])
                );
            Tavszazalek = int.Parse(v[4]);
        }
    }
}
