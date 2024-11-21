using BD_COUNTRIES_HW.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_COUNTRIES_HW
{
    internal class Program
    {

        static string connectionString = ConfigurationManager
                                         .ConnectionStrings["MyConnString"]
                                         .ConnectionString;

        static void Main(string[] args)
        {
            CountriesDataContext db = new CountriesDataContext(connectionString);

            Console.WriteLine("----- Отобразить всю информацию о странах -----");
            DisplayAllCountries(db);

            Console.WriteLine("----- Отобразить название стран -----");
            CountriesName(db);

            Console.WriteLine("----- Отобразить название столиц -----");
            CapitalsName(db);

            Console.WriteLine("----- Отобразить название всех европейских стран -----");
            EuropCountries(db);

            Console.WriteLine("----- Отобразить название стран с площадью большей конкретного числа -----");
            Square(db);

            Console.WriteLine("----- Отобразить все столицы, у которых в названии есть буквы a, p -----");
            CapitalsLettersAP(db);

            Console.WriteLine("----- Отобразить все столицы, у которых название начинается с буквы k -----");
            CapitalsStartsWithK(db);

            Console.WriteLine("----- Отобразить название стран, у которых площадь находится в указанном диапазоне -----");
            CountriesSquareBetween(db);

            Console.WriteLine("----- Отобразить название стран, у которых количество\r\nжителей больше указанного числа -----");
            CountriesPeopleQuantity(db);

            Console.WriteLine("----- Показать топ-5 стран по площади -----");
            TopFiveSquareCountries(db);

            Console.WriteLine("----- Показать топ-5 столиц по количеству жителей -----");
            TopFiveCapitalsPopulation(db);

            Console.WriteLine("----- Показать страну с самой большой площадью -----");
            CountryTheBiggestArea(db);

            Console.WriteLine("----- Показать страну с самой маленькой площадью в Европе -----");
            TheSmallestAreaInEurope(db);

            Console.WriteLine("----- Показать среднюю площадь стран в Европе -----");
            AVGArea(db);

            Console.WriteLine("----- Показать общее количество стран -----");
            QuantityCountries(db);

            Console.WriteLine("----- Показать часть света с максимальным количеством стран и  количество стран в каждой части света -----");
            MaxQuantityCountries(db);
        }

        public static void DisplayAllCountries(CountriesDataContext db)
        {
            var countries = db.Countries;

            foreach(var c in countries)
                Console.WriteLine(c);
        }

        public static void CountriesName(CountriesDataContext db)
        {
            var countries = db.Countries.Select(c => c.CountryName);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void CapitalsName(CountriesDataContext db)
        {
            var capitals = from c in db.Countries
                           select c.CapitalName;

            foreach (var c in capitals)
                Console.WriteLine(c);
        }

        public static void EuropCountries(CountriesDataContext db)
        {
            var EUCountries = db.Countries
                              .Where(c => c.Continent == "Europe")
                              .Select(c => c.CountryName);

            foreach (var c in EUCountries)
                Console.WriteLine(c);
        }

        public static void Square(CountriesDataContext db)
        {
            decimal sq = 10000000.5M;

            var countries = from c in db.Countries
                            where c.Area > sq
                            select new
                            {
                                name = c.CountryName,
                                area = c.Area
                            };

            foreach (var c in countries)
            {
                Console.WriteLine($"Country: {c.name}, Area: {c.area}");
            }
        }

        public static void CapitalsLettersAP(CountriesDataContext db)
        {
            var countries = db.Countries
                            .Where(c => c.CapitalName.Contains("a") || c.CapitalName.Contains("p"))
                            .Select(c => c.CapitalName);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void CapitalsStartsWithK(CountriesDataContext db)
        {
            var countries = db.Countries
                            .Where(c => c.CapitalName.StartsWith("K"))
                            .Select(c => c.CapitalName);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void CountriesSquareBetween(CountriesDataContext db)
        {
            decimal sqLeft = 1000000.5M;
            decimal sqRight = 10000000.5M;


            var countries = db.Countries
                            .Where(c => c.Area >= sqLeft && c.Area <= sqRight)
                            .Select(c => c.CountryName);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void CountriesPeopleQuantity(CountriesDataContext db)
        {
            int population = 15000000;

            var countries = db.Countries
                            .Where (c => c.Area > population)
                            .Select(c => c.CountryName);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void TopFiveSquareCountries(CountriesDataContext db)
        {
            var countries = db.Countries
                            .OrderByDescending(c => c.Area)
                            .Select(c => c.CountryName)
                            .Take(5);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void TopFiveCapitalsPopulation(CountriesDataContext db)
        {
            var countries = db.Countries
                            .OrderByDescending(c => c.Population)
                            .Select(c => c.CapitalName)
                            .Take(5);

            foreach (var c in countries)
                Console.WriteLine(c);
        }

        public static void CountryTheBiggestArea(CountriesDataContext db)
        {
            var country = db.Countries
                          .OrderByDescending(c => c.Area)
                          .Select(c => c.CountryName)
                          .FirstOrDefault();

            if (country != null)
                Console.WriteLine(country);
            else
                Console.WriteLine("Нет данных о странах.");
        }

        public static void TheSmallestAreaInEurope(CountriesDataContext db)
        {
            var country = db.Countries
                          .Where(c => c.Continent == "Europe")
                          .OrderBy(c => c.Area)
                          .Select(c => c.CountryName)
                          .FirstOrDefault();

            if (country != null)
                Console.WriteLine(country);
            else
                Console.WriteLine("Нет данных о стране.");
        }

        public static void AVGArea(CountriesDataContext db)
        {
            var country = db.Countries
                          .Where(c => c.Continent == "Europe")
                          .Average(c => c.Area);

            Console.WriteLine(country);
        }

        public static void QuantityCountries(CountriesDataContext db)
        {
            var country = db.Countries
                          .Count(c => c.CountryName != null);

            Console.WriteLine(country);
        }

        public static void MaxQuantityCountries(CountriesDataContext db)
        {
            var europe = db.Countries
                         .Count(c => c.Continent == "Europe");

            var northAmerica = db.Countries
                               .Count(c => c.Continent == "North America");

            var southAmerica = db.Countries
                               .Count(c => c.Continent == "South America");

            var asia = db.Countries
                       .Count(c => c.Continent == "Asia");

            var africa = db.Countries
                         .Count(c => c.Continent == "Africa");

            var continentCounts = new Dictionary<string, int>
            {
                { "Europe", europe },
                { "North America", northAmerica },
                { "South America", southAmerica },
                { "Asia", asia },
                { "Africa", africa }
            };

            var maxContinent = continentCounts.Aggregate((l, r) => l.Value > r.Value ? l : r);

            Console.WriteLine($"Континент с наибольшим количеством стран: {maxContinent.Key} ({maxContinent.Value} стран)\n");

            foreach (var continent in continentCounts)
                Console.WriteLine($"{continent.Key}: {continent.Value} стран");
        }
    }
}