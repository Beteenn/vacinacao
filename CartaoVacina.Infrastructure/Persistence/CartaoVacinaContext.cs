using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CartaoVacina.DataAccess.Persistence;

public sealed class CartaoVacinaContext : DbContext, IUnitOfWork
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
