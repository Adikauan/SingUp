using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Infrastructure.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.SingUp.Infrastructure.EntityFramework.Context
{
    public class SingUpDbContext : DbContext
    {
        public const string DEFAULT_MIGRATIONS_TABLE = "__EFMigrationsHistory";

        public const string DEFAULT_SCHEMA = nameof(SingUp);
        DbSet<User> Users { get; set; } 

        public SingUpDbContext(DbContextOptions<SingUpDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Restante da configuração do DbContext
        }
    }
}
