using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class VacinaCardenetaVacinaMapping : EntityMapping<VacinaCardenetaVacina>
{
    public override void Configure(EntityTypeBuilder<VacinaCardenetaVacina> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(VacinaCardenetaVacina));

        builder.HasOne(x => x.Vacina)
            .WithMany()
            .HasForeignKey(x => x.VacinaId)
            .IsRequired();

        builder.HasOne(v => v.Cardeneta)
            .WithMany(c => c.Vacinas)
            .HasForeignKey(v => v.CardenetaId)
            .IsRequired();
    }
}
