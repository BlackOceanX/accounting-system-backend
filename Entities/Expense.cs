using System;
using System.Collections.Generic;

namespace Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string VendorName { get; set; }
        public string VendorDetail { get; set; }
        public string Project { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime Date { get; set; }
        public int CreditTerm { get; set; }
        public DateTime DueDate { get; set; }
        public string Currency { get; set; }
        public decimal Discount { get; set; }
        public bool VatIncluded { get; set; }
        public string Remark { get; set; }
        public string InternalNote { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ExpenseItem> ExpenseItems { get; set; }
    }
} 