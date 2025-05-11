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
            // Get the existing expense with its items
            var existingExpense = await _context.Expenses
                .Include(e => e.ExpenseItems)
                .FirstOrDefaultAsync(e => e.Id == expense.Id);

            if (existingExpense == null)
                throw new KeyNotFoundException($"Expense with ID {expense.Id} not found");

            // Update expense properties
            _context.Entry(existingExpense).CurrentValues.SetValues(expense);

            // Handle expense items
            var existingItems = existingExpense.ExpenseItems.ToList();
            var updatedItems = expense.ExpenseItems ?? new List<ExpenseItem>();

            // Remove items that are no longer present
            var itemsToRemove = existingItems
                .Where(ei => !updatedItems.Any(ui => ui.Id == ei.Id))
                .ToList();
            foreach (var item in itemsToRemove)
            {
                _context.ExpenseItems.Remove(item);
            }

            // Add new items and update existing ones
            foreach (var item in updatedItems)
            {
                var existingItem = existingItems.FirstOrDefault(ei => ei.Id == item.Id);
                if (existingItem == null)
                {
                    // New item
                    item.ExpenseId = expense.Id;
                    _context.ExpenseItems.Add(item);
                }
                else
                {
                    // Update existing item
                    _context.Entry(existingItem).CurrentValues.SetValues(item);
                }
            }

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