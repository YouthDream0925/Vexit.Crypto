using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Web.Models
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {
        }

        public DbSet<CreateWallet> TodoItems { get; set; } = null!;
    }
}
