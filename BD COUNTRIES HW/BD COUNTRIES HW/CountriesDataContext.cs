using BD_COUNTRIES_HW.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_COUNTRIES_HW
{
    internal class CountriesDataContext : DataContext
    {
        public Table<Country> Countries;

        public CountriesDataContext(string connectionString)
                                        : base(connectionString) { }
    }
}