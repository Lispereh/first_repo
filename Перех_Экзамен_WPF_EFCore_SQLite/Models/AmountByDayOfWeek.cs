using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenes_Exam_Beth_Perekh.Models
{
    public class AmountByDayOfWeek
    {
        public DayOfWeek DayOfWeek { get; set; }
        public decimal Amount { get; set; }

        public AmountByDayOfWeek(DayOfWeek dayOfWeek, decimal amount)
        {
            DayOfWeek = dayOfWeek;
            Amount = amount;
        }
    }
}