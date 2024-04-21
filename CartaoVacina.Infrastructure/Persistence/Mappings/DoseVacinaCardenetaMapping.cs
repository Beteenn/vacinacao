using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class DoseVacinaCardenetaMapping : EntityMapping<DoseVacinaCardeneta>
{
    public override void Configure(EntityTypeBuilder<DoseVacinaCardeneta> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(DoseVacinaCardeneta));

        builder.Property(d => d.NumeroDose)
            .IsRequired();

        builder.Property(d => d.DataAplicacao)
            .IsRequired();

        builder.HasOne(d => d.CardenetaVacina)
            .WithMany(c => c.Doses)
            .HasForeignKey(d => d.CardenetaVacinaId);
    }
}
