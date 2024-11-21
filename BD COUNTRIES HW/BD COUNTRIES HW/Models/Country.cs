using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_COUNTRIES_HW.Models
{
    [Table(Name = "Countries")]
    public class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string CountryName { get; set; }

        [Column]
        public string CapitalName { get; set; }

        [Column]
        public long? Population {  get; set; }

        [Column]
        public decimal? Area { get; set; }
        
        [Column]
        public string Continent { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Country: {CountryName}, Capital: {CapitalName} " +
                   $"Population: {Population}, Area: {Area}, Continent: {Continent}\n";
        }
    }
}