using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenes_Exam_Beth_Perekh.Models
{
    public class SumExpensesPeriod
    {
        public string CategoryName { get; set; }
        public decimal Sum { get; set; }

        public SumExpensesPeriod(string categoryName, decimal sum)
        {
            CategoryName = categoryName;
            Sum = sum;
        }
    }
}