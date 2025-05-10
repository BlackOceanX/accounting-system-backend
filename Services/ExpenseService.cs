using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Entities;
using Repositories;
using System;

namespace Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Expense>> GetAllExpensesAsync() => _repository.GetAllAsync();
        
        public async Task<PaginationResult<Expense>> GetPaginatedExpensesAsync(int pageNumber, int pageSize)
        {
            var expenses = await _repository.GetAllAsync();
            var totalCount = expenses.Count();
            var totalPages = (int)System.Math.Ceiling(totalCount / (double)pageSize);
            
            var items = expenses
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return new PaginationResult<Expense>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public Task<Expense> GetExpenseByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateExpenseAsync(Expense expense) => _repository.AddAsync(expense);
        public Task UpdateExpenseAsync(Expense expense) => _repository.UpdateAsync(expense);
        public Task DeleteExpenseAsync(int id) => _repository.DeleteAsync(id);
        public Task<string> GetLatestDocumentNumberAsync(DateTime date) => _repository.GetLatestDocumentNumberAsync(date);
    }
} 