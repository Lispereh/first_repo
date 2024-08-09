using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listOfBooks
{
    internal class Book
    {

        public string Name {  get; set; }
        public string Author { get; set; }
        public int PagesNumber { get; set; }

        public override string ToString()
        {
            return $"\"{Name}\", {Author}, {PagesNumber:N0} стр.";
        }

    }
}