using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CartaoVacina.DataAccess.Persistence;

public sealed class CartaoVacinaContext : DbContext
{
    public CartaoVacinaContext(DbContextOptions<CartaoVacinaContext> opts) : base(opts) { }

    // DbSets
    public DbSet<Pessoa> Pessoas { get; set; }


    // Aplica todos os mappings da aplicacao
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
