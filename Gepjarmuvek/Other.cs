using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepjarmuvek
{
    public class Elado
    {
        public int Id { get; private set; }
        public string Nev { get; private set; }
        public string Telefon { get; private set; }

        public Elado(int id, string nev, string telefon)
        {
            Id = id;
            Nev = nev;
            Telefon = telefon;
        }
    }
    public class Kategoria
    {
        public int Id { get; private set; }
        public string Nev { get; private set; }

        public Kategoria(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }
    }

    public class Gyarto
    {
        public int Id { get; private set; }
        public string Nev { get; private set; }
        public string Orszag { get; private set; }

        public Gyarto(int id, string nev, string orszag)
        {
            Id = id;
            Nev = nev;
            Orszag = orszag;
        }
    }


}
