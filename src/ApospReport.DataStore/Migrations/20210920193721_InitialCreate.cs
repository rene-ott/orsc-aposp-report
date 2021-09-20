using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApospReport.DataStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Attack_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Attack_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Defense_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Defense_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Strength_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Strength_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Hits_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Hits_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Ranged_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Ranged_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Prayer_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Prayer_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Magic_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Magic_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Cooking_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Cooking_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Woodcut_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Woodcut_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Fletching_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Fletching_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Fishing_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Fishing_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Firemaking_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Firemaking_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Crafting_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Crafting_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Smithing_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Smithing_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Mining_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Mining_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Herblaw_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Herblaw_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Agility_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Agility_BaseLevel = table.Column<int>(type: "integer", nullable: true),
                    Thieving_CurrentLevel = table.Column<int>(type: "integer", nullable: true),
                    Thieving_BaseLevel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    IsStackable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    DefinitionId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankItems_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankItems_ItemDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "ItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    DefinitionId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItems_ItemDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "ItemDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankItems_AccountId",
                table: "BankItems",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankItems_DefinitionId",
                table: "BankItems",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_AccountId",
                table: "InventoryItems",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_DefinitionId",
                table: "InventoryItems",
                column: "DefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankItems");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ItemDefinitions");
        }
    }
}
