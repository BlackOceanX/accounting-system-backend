using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Repositories;

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
        public Task<Expense> GetExpenseByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateExpenseAsync(Expense expense) => _repository.AddAsync(expense);
        public Task UpdateExpenseAsync(Expense expense) => _repository.UpdateAsync(expense);
        public Task DeleteExpenseAsync(int id) => _repository.DeleteAsync(id);
    }
} 