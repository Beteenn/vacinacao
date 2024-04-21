using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class VacinaMapping : EntityMapping<Vacina>
{
    public override void Configure(EntityTypeBuilder<Vacina> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(Vacina));

        builder.Property(x => x.Nome)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.QuantidadeDoses).IsRequired();
        builder.Property(x => x.QuantidadeReforcos).IsRequired();
    }
}