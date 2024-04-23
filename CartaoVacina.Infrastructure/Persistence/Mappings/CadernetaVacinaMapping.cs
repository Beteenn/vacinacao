using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class CadernetaVacinaMapping : EntityMapping<CadernetaVacina>
{
    public override void Configure(EntityTypeBuilder<CadernetaVacina> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(CadernetaVacina));

        builder
            .HasOne(c => c.Pessoa)
            .WithOne(p => p.CadernetaVacina)
            .HasForeignKey<CadernetaVacina>(c => c.PessoaId)
            .IsRequired();
    }
}