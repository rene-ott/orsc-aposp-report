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
                    attack_current_level = table.Column<int>(type: "integer", nullable: true),
                    attack_base_level = table.Column<int>(type: "integer", nullable: true),
                    defense_current_level = table.Column<int>(type: "integer", nullable: true),
                    defense_base_level = table.Column<int>(type: "integer", nullable: true),
                    strength_current_level = table.Column<int>(type: "integer", nullable: true),
                    strength_base_level = table.Column<int>(type: "integer", nullable: true),
                    hits_current_level = table.Column<int>(type: "integer", nullable: true),
                    hits_base_level = table.Column<int>(type: "integer", nullable: true),
                    ranged_current_level = table.Column<int>(type: "integer", nullable: true),
                    ranged_base_level = table.Column<int>(type: "integer", nullable: true),
                    prayer_current_level = table.Column<int>(type: "integer", nullable: true),
                    prayer_base_level = table.Column<int>(type: "integer", nullable: true),
                    magic_current_level = table.Column<int>(type: "integer", nullable: true),
                    magic_base_level = table.Column<int>(type: "integer", nullable: true),
                    cooking_current_level = table.Column<int>(type: "integer", nullable: true),
                    cooking_base_level = table.Column<int>(type: "integer", nullable: true),
                    woodcut_current_level = table.Column<int>(type: "integer", nullable: true),
                    woodcut_base_level = table.Column<int>(type: "integer", nullable: true),
                    fletching_current_level = table.Column<int>(type: "integer", nullable: true),
                    fletching_base_level = table.Column<int>(type: "integer", nullable: true),
                    fishing_current_level = table.Column<int>(type: "integer", nullable: true),
                    fishing_base_level = table.Column<int>(type: "integer", nullable: true),
                    firemaking_current_level = table.Column<int>(type: "integer", nullable: true),
                    firemaking_base_level = table.Column<int>(type: "integer", nullable: true),
                    crafting_current_level = table.Column<int>(type: "integer", nullable: true),
                    crafting_base_level = table.Column<int>(type: "integer", nullable: true),
                    smithing_current_level = table.Column<int>(type: "integer", nullable: true),
                    smithing_base_level = table.Column<int>(type: "integer", nullable: true),
                    mining_current_level = table.Column<int>(type: "integer", nullable: true),
                    mining_base_level = table.Column<int>(type: "integer", nullable: true),
                    herblaw_current_level = table.Column<int>(type: "integer", nullable: true),
                    herblaw_base_level = table.Column<int>(type: "integer", nullable: true),
                    agility_current_level = table.Column<int>(type: "integer", nullable: true),
                    agility_base_level = table.Column<int>(type: "integer", nullable: true),
                    thieving_current_level = table.Column<int>(type: "integer", nullable: true),
                    thieving_base_level = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item_definitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
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
                    count = table.Column<int>(type: "integer", nullable: false),
                    definition_id = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false)
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
                        name: "fk_bank_items_item_definitions_definition_id",
                        column: x => x.definition_id,
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
                    count = table.Column<int>(type: "integer", nullable: false),
                    definition_id = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false)
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
                        name: "fk_inventory_items_item_definitions_definition_id",
                        column: x => x.definition_id,
                        principalTable: "item_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bank_items_account_id",
                table: "bank_items",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_bank_items_definition_id",
                table: "bank_items",
                column: "definition_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_items_account_id",
                table: "inventory_items",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_items_definition_id",
                table: "inventory_items",
                column: "definition_id");
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
