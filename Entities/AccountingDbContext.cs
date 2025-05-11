using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasMany(e => e.ExpenseItems)
                .WithOne()
                .HasForeignKey(i => i.ExpenseId);

            // Add indexes for searchable fields
            modelBuilder.Entity<Expense>()
                .HasIndex(e => e.VendorName);

            modelBuilder.Entity<Expense>()
                .HasIndex(e => e.VendorDetail);

            modelBuilder.Entity<Expense>()
                .HasIndex(e => e.DocumentNumber);

            modelBuilder.Entity<Expense>()
                .HasIndex(e => e.Project);

            modelBuilder.Entity<ExpenseItem>()
                .HasIndex(e => e.Description);
        }
    }
} 