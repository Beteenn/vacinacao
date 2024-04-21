using CartaoVacina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class PessoaMapping : EntityMapping<Pessoa>
{
    public override void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(Pessoa));

        builder.Property(x => x.Nome)
            .HasMaxLength(120)
            .IsRequired();
    }
}
