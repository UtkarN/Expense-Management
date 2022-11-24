using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ExpenseManagement.Datalayer
{
    public class DBcontextExpenseMgt : DbContext
    {
        public DBcontextExpenseMgt(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<ExpenseCategoryEntity> ExpenseCategory { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
