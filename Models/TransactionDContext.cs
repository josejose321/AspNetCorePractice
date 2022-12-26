using Microsoft.EntityFrameworkCore;

namespace practiceAuthentication.Models
{
    public class TransactionDContext : DbContext
    {
        public TransactionDContext(DbContextOptions<TransactionDContext> options) : base(options)
        {

        }

        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<Practice>? Practices { get; set; }
    }
}
