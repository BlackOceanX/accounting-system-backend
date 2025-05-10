using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;
using System.Linq;
using System;

namespace Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AccountingDbContext _context;
        public ExpenseRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync() =>
            await _context.Expenses.Include(e => e.ExpenseItems).ToListAsync();

        public async Task<Expense> GetByIdAsync(int id) =>
            await _context.Expenses.Include(e => e.ExpenseItems)
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetLatestDocumentNumberAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1).AddTicks(-1);

            var latestExpense = await _context.Expenses
                .Where(e => e.Date >= startOfDay && e.Date <= endOfDay)
                .OrderByDescending(e => e.DocumentNumber)
                .FirstOrDefaultAsync();

            return latestExpense?.DocumentNumber ?? string.Empty;
        }
    }
} 