using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sales> salesCollection = new List<Sales>
            {
                new Sales("Katya", 2510m, "comment"),
                new Sales("Katya", 500m, "comment"),
                new Sales("Katya", 750m, "comment"),
                new Sales("Katya", 12000m, "comment"),
                new Sales("Katya", 120m, "comment"),

                new Sales("Alina", 150m, "comment"),
                new Sales("Alina", 200m, "comment"),
                new Sales("Alina", 180m, "comment"),
                new Sales("Alina", 2500m, "comment"),
                new Sales("Alina", 32000m, "comment"),

                new Sales("Maksim", 3000m, "comment"),
                new Sales("Maksim", 950m, "comment"),
                new Sales("Maksim", 1100m, "comment"),
                new Sales("Maksim", 6700m, "comment"),
                new Sales("Maksim", 145m, "comment"),
                new Sales("Maksim", 82m, "comment"),

                new Sales("Alina", 800m, ""),
                new Sales("Katya", 1300m, "  "),
                new Sales("Katya", 33m, ""),
                new Sales("Alina", 120m, null),
                new Sales("Maksim", 7800m, "   ")
            };

            bonusAdjust(salesCollection);
            premiumBonus(salesCollection);

            var sortedSalesCollection = salesCollection.GroupBy(x => x.salesManager);

            foreach (var sale in sortedSalesCollection)
            {
                Console.Write($"{sale.Key} - ");
                Console.WriteLine($"{Decimal.Round(sale.Sum(x => x.bonus))}");
            }
        }

        public static List<Sales> bonusAdjust(List<Sales> collection)
        {
            foreach (var sale in collection)
            {
                if (string.IsNullOrWhiteSpace(sale.comment))
                {
                    sale.bonus = sale.price * 0.005m;
                }
            }
            return collection;
        }
        //  a * 0.4 + b * 0.4 = 0.4 * ( a + b )
        public static List<Sales> premiumBonus(List<Sales> collection)
        {
            int counter = collection.Count(x => !string.IsNullOrWhiteSpace(x.comment));
            if (counter > 15)
            {
                collection.ForEach(x => x.bonus += x.bonus * 0.004m);
            }
            return collection;
        }
    }
}
