using System;

namespace Entities
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public Expense? Expense { get; set; }
    }
} 