using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class CardenetaVacinaMapping : EntityMapping<CardenetaVacina>
{
    public override void Configure(EntityTypeBuilder<CardenetaVacina> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(CardenetaVacina));

        builder
            .HasOne(c => c.Pessoa)
            .WithOne(p => p.CardenetaVacina)
            .HasForeignKey<CardenetaVacina>(c => c.PessoaId)
            .IsRequired();
    }
}