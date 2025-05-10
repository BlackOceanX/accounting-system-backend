using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services;
using Entities;
using System;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _service;
        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100; // Limit maximum page size
            
            return Ok(await _service.GetPaginatedExpensesAsync(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetExpenseByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Expense expense)
        {
            // Convert DateTime values to UTC
            expense.Date = DateTime.SpecifyKind(expense.Date, DateTimeKind.Utc);
            expense.DueDate = DateTime.SpecifyKind(expense.DueDate, DateTimeKind.Utc);
            
            await _service.CreateExpenseAsync(expense);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Expense expense)
        {
            if (id != expense.Id) return BadRequest();
            
            // Convert DateTime values to UTC
            expense.Date = DateTime.SpecifyKind(expense.Date, DateTimeKind.Utc);
            expense.DueDate = DateTime.SpecifyKind(expense.DueDate, DateTimeKind.Utc);
            
            await _service.UpdateExpenseAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteExpenseAsync(id);
            return Ok();
        }
    }
} 