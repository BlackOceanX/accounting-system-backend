using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using System;

namespace Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(int id);
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(int id);
        Task<string> GetLatestDocumentNumberAsync(DateTime date);
    }
} 