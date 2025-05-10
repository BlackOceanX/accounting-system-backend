using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using System;

namespace Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<PaginationResult<Expense>> GetPaginatedExpensesAsync(int pageNumber, int pageSize);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task CreateExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
        Task<string> GetLatestDocumentNumberAsync(DateTime date);
    }
} 