using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services;
using Entities;

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
        public async Task<IActionResult> Get() => Ok(await _service.GetAllExpensesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetExpenseByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Expense expense)
        {
            await _service.CreateExpenseAsync(expense);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Expense expense)
        {
            if (id != expense.Id) return BadRequest();
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