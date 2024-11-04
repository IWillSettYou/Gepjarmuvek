using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepjarmuvek
{
    public class Jarmu
    {
        public int Id { get; private set; }
        public string Rendszam { get; private set; }
        public string LatLong { get; private set; }
        public string Tipus { get; private set; }
        public string Szin { get; private set; }
        public int Ar { get; private set; }
        public int Evjarat { get; private set; }
        public string Leiras { get; private set; }
        public string KepURL { get; private set; }
        public bool Deleted { get; private set; }

        public Jarmu(int id, string rendszam, string latlong, string tipus, string szin, int ar, int evjarat, string leiras, string kepURL, bool deleted)
        {
            Id = id;
            Rendszam = rendszam;
            LatLong = latlong;
            Tipus = tipus;
            Szin = szin;
            Ar = ar;
            Evjarat = evjarat;
            Leiras = leiras;
            KepURL = kepURL;
            Deleted = deleted;
        }

        public static List<Jarmu> LoadFromCsv(string fileName)
        {
            var jarmuvek = new List<Jarmu>();
            var lines = File.ReadAllLines(fileName);
            for (int i = 1; i < lines.Length; i++)
            {
                var columns = lines[i].Split(';');
                jarmuvek.Add(new Jarmu(
                    int.Parse(columns[0]), columns[1], columns[2], columns[3], columns[4],
                    int.Parse(columns[5]), int.Parse(columns[6]), columns[7], columns[8], Convert.ToBoolean(Convert.ToInt32(columns[9]))));
            }
            return jarmuvek;
        }

        public double DistanceTo(string gpsCoordinates)
        {
            var latLong1 = LatLong.Split(',');
            var latLong2 = gpsCoordinates.Split(',');
            double x1 = double.Parse(latLong1[0]);
            double y1 = double.Parse(latLong1[1]);
            double x2 = double.Parse(latLong2[0]);
            double y2 = double.Parse(latLong2[1]);

            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
