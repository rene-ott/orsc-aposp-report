﻿// <auto-generated />
using System;
using ApospReport.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApospReport.DataStore.Migrations
{
    [DbContext(typeof(ApospReportDbContext))]
    partial class ApospReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ApospReport.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("BankViewTimestamp")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("bank_view_timestamp");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.BankItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<int>("ItemDefinitionId")
                        .HasColumnType("integer")
                        .HasColumnName("item_definition_id");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasColumnName("position");

                    b.HasKey("Id")
                        .HasName("pk_bank_items");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_bank_items_account_id");

                    b.HasIndex("ItemDefinitionId")
                        .HasDatabaseName("ix_bank_items_item_definition_id");

                    b.ToTable("bank_items");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<int>("ItemDefinitionId")
                        .HasColumnType("integer")
                        .HasColumnName("item_definition_id");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasColumnName("position");

                    b.HasKey("Id")
                        .HasName("pk_inventory_items");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_inventory_items_account_id");

                    b.HasIndex("ItemDefinitionId")
                        .HasDatabaseName("ix_inventory_items_item_definition_id");

                    b.ToTable("inventory_items");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.ItemDefinition", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<bool>("IsStackable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_stackable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_item_definitions");

                    b.ToTable("item_definitions");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.Account", b =>
                {
                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Agility", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("agility_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("agility_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Attack", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("attack_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("attack_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Cooking", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("cooking_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("cooking_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Crafting", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("crafting_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("crafting_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Defense", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("defense_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("defense_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Firemaking", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("firemaking_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("firemaking_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Fishing", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("fishing_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("fishing_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Fletching", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("fletching_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("fletching_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Herblaw", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("herblaw_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("herblaw_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Hits", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("hits_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("hits_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Magic", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("magic_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("magic_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Mining", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("mining_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("mining_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Prayer", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("prayer_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("prayer_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Ranged", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("ranged_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("ranged_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Smithing", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("smithing_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("smithing_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Strength", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("strength_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("strength_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Thieving", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("thieving_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("thieving_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.OwnsOne("ApospReport.Domain.Models.Skill", "Woodcut", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("BaseLevel")
                                .HasColumnType("integer")
                                .HasColumnName("woodcut_base_level");

                            b1.Property<int>("CurrentLevel")
                                .HasColumnType("integer")
                                .HasColumnName("woodcut_current_level");

                            b1.HasKey("AccountId")
                                .HasName("pk_accounts");

                            b1.ToTable("accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.Navigation("Agility")
                        .IsRequired();

                    b.Navigation("Attack")
                        .IsRequired();

                    b.Navigation("Cooking")
                        .IsRequired();

                    b.Navigation("Crafting")
                        .IsRequired();

                    b.Navigation("Defense")
                        .IsRequired();

                    b.Navigation("Firemaking")
                        .IsRequired();

                    b.Navigation("Fishing")
                        .IsRequired();

                    b.Navigation("Fletching")
                        .IsRequired();

                    b.Navigation("Herblaw")
                        .IsRequired();

                    b.Navigation("Hits")
                        .IsRequired();

                    b.Navigation("Magic")
                        .IsRequired();

                    b.Navigation("Mining")
                        .IsRequired();

                    b.Navigation("Prayer")
                        .IsRequired();

                    b.Navigation("Ranged")
                        .IsRequired();

                    b.Navigation("Smithing")
                        .IsRequired();

                    b.Navigation("Strength")
                        .IsRequired();

                    b.Navigation("Thieving")
                        .IsRequired();

                    b.Navigation("Woodcut")
                        .IsRequired();
                });

            modelBuilder.Entity("ApospReport.Domain.Models.BankItem", b =>
                {
                    b.HasOne("ApospReport.Domain.Models.Account", "Account")
                        .WithMany("BankItems")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_bank_items_accounts_account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApospReport.Domain.Models.ItemDefinition", "ItemDefinition")
                        .WithMany("BankItems")
                        .HasForeignKey("ItemDefinitionId")
                        .HasConstraintName("fk_bank_items_item_definitions_item_definition_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ItemDefinition");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.InventoryItem", b =>
                {
                    b.HasOne("ApospReport.Domain.Models.Account", "Account")
                        .WithMany("InventoryItems")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_inventory_items_accounts_account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApospReport.Domain.Models.ItemDefinition", "ItemDefinition")
                        .WithMany("InventoryItems")
                        .HasForeignKey("ItemDefinitionId")
                        .HasConstraintName("fk_inventory_items_item_definitions_item_definition_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ItemDefinition");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.Account", b =>
                {
                    b.Navigation("BankItems");

                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("ApospReport.Domain.Models.ItemDefinition", b =>
                {
                    b.Navigation("BankItems");

                    b.Navigation("InventoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}
