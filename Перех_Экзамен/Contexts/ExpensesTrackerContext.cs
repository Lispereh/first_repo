using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expenes_Exam_Beth_Perekh.Models;
using Expenes_Exam_Beth_Perekh.Models;

namespace Expenes_Exam_Beth_Perekh.Contexts
{
    public class ExpensesTrackerContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public ExpensesTrackerContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Expenses.db");
        }
    }
}