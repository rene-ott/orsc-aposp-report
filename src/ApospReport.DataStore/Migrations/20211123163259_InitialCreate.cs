﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApospReport.DataStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    base64encoded_screenshot = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    attack_xp = table.Column<int>(type: "integer", nullable: false),
                    attack_current_level = table.Column<int>(type: "integer", nullable: false),
                    attack_level = table.Column<int>(type: "integer", nullable: false),
                    defense_xp = table.Column<int>(type: "integer", nullable: false),
                    defense_current_level = table.Column<int>(type: "integer", nullable: false),
                    defense_level = table.Column<int>(type: "integer", nullable: false),
                    strength_xp = table.Column<int>(type: "integer", nullable: false),
                    strength_current_level = table.Column<int>(type: "integer", nullable: false),
                    strength_level = table.Column<int>(type: "integer", nullable: false),
                    hits_xp = table.Column<int>(type: "integer", nullable: false),
                    hits_current_level = table.Column<int>(type: "integer", nullable: false),
                    hits_level = table.Column<int>(type: "integer", nullable: false),
                    ranged_xp = table.Column<int>(type: "integer", nullable: false),
                    ranged_current_level = table.Column<int>(type: "integer", nullable: false),
                    ranged_level = table.Column<int>(type: "integer", nullable: false),
                    prayer_xp = table.Column<int>(type: "integer", nullable: false),
                    prayer_current_level = table.Column<int>(type: "integer", nullable: false),
                    prayer_level = table.Column<int>(type: "integer", nullable: false),
                    magic_xp = table.Column<int>(type: "integer", nullable: false),
                    magic_current_level = table.Column<int>(type: "integer", nullable: false),
                    magic_level = table.Column<int>(type: "integer", nullable: false),
                    cooking_xp = table.Column<int>(type: "integer", nullable: false),
                    cooking_current_level = table.Column<int>(type: "integer", nullable: false),
                    cooking_level = table.Column<int>(type: "integer", nullable: false),
                    woodcut_xp = table.Column<int>(type: "integer", nullable: false),
                    woodcut_current_level = table.Column<int>(type: "integer", nullable: false),
                    woodcut_level = table.Column<int>(type: "integer", nullable: false),
                    fletching_xp = table.Column<int>(type: "integer", nullable: false),
                    fletching_current_level = table.Column<int>(type: "integer", nullable: false),
                    fletching_level = table.Column<int>(type: "integer", nullable: false),
                    fishing_xp = table.Column<int>(type: "integer", nullable: false),
                    fishing_current_level = table.Column<int>(type: "integer", nullable: false),
                    fishing_level = table.Column<int>(type: "integer", nullable: false),
                    firemaking_xp = table.Column<int>(type: "integer", nullable: false),
                    firemaking_current_level = table.Column<int>(type: "integer", nullable: false),
                    firemaking_level = table.Column<int>(type: "integer", nullable: false),
                    crafting_xp = table.Column<int>(type: "integer", nullable: false),
                    crafting_current_level = table.Column<int>(type: "integer", nullable: false),
                    crafting_level = table.Column<int>(type: "integer", nullable: false),
                    smithing_xp = table.Column<int>(type: "integer", nullable: false),
                    smithing_current_level = table.Column<int>(type: "integer", nullable: false),
                    smithing_level = table.Column<int>(type: "integer", nullable: false),
                    mining_xp = table.Column<int>(type: "integer", nullable: false),
                    mining_current_level = table.Column<int>(type: "integer", nullable: false),
                    mining_level = table.Column<int>(type: "integer", nullable: false),
                    herblaw_xp = table.Column<int>(type: "integer", nullable: false),
                    herblaw_current_level = table.Column<int>(type: "integer", nullable: false),
                    herblaw_level = table.Column<int>(type: "integer", nullable: false),
                    agility_xp = table.Column<int>(type: "integer", nullable: false),
                    agility_current_level = table.Column<int>(type: "integer", nullable: false),
                    agility_level = table.Column<int>(type: "integer", nullable: false),
                    thieving_xp = table.Column<int>(type: "integer", nullable: false),
                    thieving_current_level = table.Column<int>(type: "integer", nullable: false),
                    thieving_level = table.Column<int>(type: "integer", nullable: false),
                    bank_view_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item_definitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_stackable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_definitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bank_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_definition_id = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bank_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_bank_items_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bank_items_item_definitions_item_definition_id",
                        column: x => x.item_definition_id,
                        principalTable: "item_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_definition_id = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inventory_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_inventory_items_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_items_item_definitions_item_definition_id",
                        column: x => x.item_definition_id,
                        principalTable: "item_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bank_items_account_id",
                table: "bank_items",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_bank_items_item_definition_id",
                table: "bank_items",
                column: "item_definition_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_items_account_id",
                table: "inventory_items",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_items_item_definition_id",
                table: "inventory_items",
                column: "item_definition_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_items");

            migrationBuilder.DropTable(
                name: "inventory_items");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "item_definitions");
        }
    }
}
