﻿using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartaoVacina.DataAccess.Persistence.Mappings;

public sealed class VacinacaoMapping : EntityMapping<Vacinacao>
{
    public override void Configure(EntityTypeBuilder<Vacinacao> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(Vacinacao));

        builder.Property(d => d.NumeroDose)
            .IsRequired();

        builder.Property(d => d.DataAplicacao)
            .IsRequired();

        builder.HasOne(x => x.Vacina)
            .WithMany()
            .HasForeignKey(x => x.VacinaId)
            .IsRequired();

        builder.HasOne(v => v.Caderneta)
            .WithMany(c => c.Vacinacoes)
            .HasForeignKey(v => v.CadernetaId)
            .IsRequired();

        builder.Property(x => x.TipoDose)
            .HasDefaultValue(TipoDose.Comum)
            .IsRequired();
    }
}
