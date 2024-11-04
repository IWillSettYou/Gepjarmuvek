using System.Reflection;

namespace Gepjarmuvek
{
    internal class Program
    {
        public static double GetAverageBmwPrice(List<Jarmu> jarmuvek)
        {
            var bmwCars = jarmuvek.Where(j => j.Tipus == "BMW" && !j.Deleted);
            if (!bmwCars.Any())
                return 0;
            return bmwCars.Average(j => j.Ar);
        }

        public static void FilterCarsByPrice(List<Jarmu> jarmuvek, int minPrice, int maxPrice)
        {
            var filteredCars = jarmuvek
                .Where(j => j.Ar >= minPrice && j.Ar <= maxPrice && !j.Deleted)
                .OrderByDescending(j => j.Ar);

            foreach (var car in filteredCars)
            {
                Console.WriteLine($"{car.Tipus}, {car.Evjarat}, {car.Ar} Ft");
            }
        }



        static void Main(string[] args)
        {
            
            var jarmuvek = Jarmu.LoadFromCsv(@"../../../gepjarmuvek.csv");

      
            Console.WriteLine("6. feladat:");
            double avgPriceBmw = GetAverageBmwPrice(jarmuvek);
            Console.WriteLine($"BMW gépjárművek átlagos eladási ára: {avgPriceBmw:F2} Ft");

       
            Console.WriteLine("7. feladat:");
            Console.WriteLine("Adjon meg egy minimum árat (500.000 és 1.000.000 Ft között):");
            int minPrice = int.Parse(Console.ReadLine());
            int maxPrice = 1000000; 
            FilterCarsByPrice(jarmuvek, minPrice, maxPrice);

            
            var distance = jarmuvek[0].DistanceTo("47.497913,19.040236");
            Console.WriteLine($"Az első jármű távolsága: {distance:F2} egység a megadott koordinátától.");
        }
    }
}
