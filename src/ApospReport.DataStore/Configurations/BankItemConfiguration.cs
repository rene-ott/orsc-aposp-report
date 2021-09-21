﻿using ApospReport.Domain;
using ApospReport.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApospReport.DataStore.Configurations
{
    internal class BankItemConfiguration : IEntityTypeConfiguration<BankItem>
    {
        public void Configure(EntityTypeBuilder<BankItem> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Count).IsRequired();
        }
    }
}
