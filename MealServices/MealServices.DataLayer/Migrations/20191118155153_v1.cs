using Microsoft.EntityFrameworkCore.Migrations;

namespace MealServices.DataLayer.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true),
                    IsAllergene = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Sandwich",
                columns: table => new
                {
                    SandwichId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandwich", x => x.SandwichId);
                });

            migrationBuilder.CreateTable(
                name: "SandwichIngredients",
                columns: table => new
                {
                    SandwichId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandwichIngredients", x => new { x.SandwichId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_SandwichIngredients_Ingredient_SandwichId",
                        column: x => x.SandwichId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SandwichIngredients_Sandwich_SandwichId",
                        column: x => x.SandwichId,
                        principalTable: "Sandwich",
                        principalColumn: "SandwichId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SandwichIngredients");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Sandwich");
        }
    }
}
