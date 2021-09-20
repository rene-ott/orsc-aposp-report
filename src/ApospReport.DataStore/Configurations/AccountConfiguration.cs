using System;
using System.Linq.Expressions;
using ApospReport.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApospReport.DataStore.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Username).HasMaxLength(12).IsRequired();

            ConfigureSkill(entity, x => x.Attack);
            ConfigureSkill(entity, x => x.Defense);
            ConfigureSkill(entity, x => x.Strength);
            ConfigureSkill(entity, x => x.Hits);
            ConfigureSkill(entity, x => x.Ranged);
            ConfigureSkill(entity, x => x.Prayer);
            ConfigureSkill(entity, x => x.Magic);
            ConfigureSkill(entity, x => x.Cooking);
            ConfigureSkill(entity, x => x.Woodcut);
            ConfigureSkill(entity, x => x.Fletching);
            ConfigureSkill(entity, x => x.Fishing);
            ConfigureSkill(entity, x => x.Firemaking);
            ConfigureSkill(entity, x => x.Crafting);
            ConfigureSkill(entity, x => x.Smithing);
            ConfigureSkill(entity, x => x.Mining);
            ConfigureSkill(entity, x => x.Herblaw);
            ConfigureSkill(entity, x => x.Agility);
            ConfigureSkill(entity, x => x.Thieving);

            entity.HasMany(x => x.InventoryItems).WithOne(x => x.Account).IsRequired();
            entity.HasMany(x => x.BankItems).WithOne(x => x.Account).IsRequired();
        }

        private static void ConfigureSkill(EntityTypeBuilder<Account> entity, Expression<Func<Account, Skill>> func)
        {
            entity.OwnsOne(func, x =>
            {
                x.Property(p => p.BaseLevel).IsRequired();
                x.Property(p => p.CurrentLevel).IsRequired();
            });
        }
    }
}
