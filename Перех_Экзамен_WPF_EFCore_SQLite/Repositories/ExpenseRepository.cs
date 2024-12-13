using Expenes_Exam_Beth_Perekh.Contexts;
using Expenes_Exam_Beth_Perekh.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenes_Exam_Beth_Perekh.Repositories
{
    public class ExpenseRepository
    {
        private readonly ExpensesTrackerContext _context;

        public ExpenseRepository(ExpensesTrackerContext context)
        {
            _context = context;
        }

        public IEnumerable<FilteredExpense> GetFilteredExpenses(DateTime? startDate, DateTime? endDate, string categoryName, string keyword)
        {
            var query = _context.Expenses.Include(e => e.Category).AsQueryable();

            if (startDate.HasValue)
                query = query.Where(e => e.Date >= startDate.Value);
            if (endDate.HasValue)
                query = query.Where(e => e.Date <= endDate.Value);
            if (!string.IsNullOrEmpty(categoryName))
                query = query.Where(e => e.Category.Name.Contains(categoryName));
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(e => e.Description.Contains(keyword));

            return query.Select(e => new FilteredExpense
            {
                Id = e.Id,
                Date = e.Date,
                Amount = e.Amount,
                Description = e.Description,
                CategoryName = e.Category.Name
            }).ToList();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void DeleteCategories(List<Category> categories)
        {
            _context.Categories.RemoveRange(categories);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public ObservableCollection<Category> GetAllCategoriesObservable()
        {
            _context.Categories.Load();
            return _context.Categories.Local.ToObservableCollection();
        }

        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void DeleteExpense(int expenseId)
        {
            var expense = _context.Expenses.Find(expenseId);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public void DeleteExpenses(List<Expense> expenses)
        {
            _context.Expenses.RemoveRange(expenses);
            _context.SaveChanges();
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public ObservableCollection<Expense> GetAllExpensesObservable()
        {
            _context.Expenses.Include(e => e.Category).Load();
            return _context.Expenses.Local.ToObservableCollection();
        }

        public IEnumerable<Expense> GetExpensesByCategoryName(string categoryName)
        {
            return _context.Expenses.Where(e => e.Category.Name.Contains(categoryName)).ToList();
        }

        public IEnumerable<Expense> GetExpensesByCategory(int categoryId)
        {
            return _context.Expenses.Include(e => e.Category).Where(e => e.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Expense> GetExpensesByMonthYear(int month, int year)
        {
            return _context.Expenses.Include(e => e.Category).Where(e => e.Date.Month == month && e.Date.Year == year).ToList();
        }

        public IEnumerable<AmountByDayOfWeek> GetAVGExpensesByDayOfWeek()
        {

            return _context.Expenses
                   .GroupBy(e => e.Date.DayOfWeek)
                   .Select(g => new AmountByDayOfWeek(g.Key, g.Average(e => e.Amount)))
                   .ToList();
        }

        public IEnumerable<SumExpensesPeriod> GetExpensesPeriods()
        {
            return _context.Expenses
                   .GroupBy(e => e.Category)
                   .Select(e => new SumExpensesPeriod(e.Key.Name, e.Sum(e => e.Amount)))
                   .ToList();
        }
    }
}