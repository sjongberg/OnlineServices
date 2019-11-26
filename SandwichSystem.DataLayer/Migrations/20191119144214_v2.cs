using Microsoft.EntityFrameworkCore.Migrations;

namespace SandwichSystem.DataLayer.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SandwichIngredients_Ingredient_SandwichId",
                table: "SandwichIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_SandwichIngredients_Sandwich_SandwichId",
                table: "SandwichIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sandwich",
                table: "Sandwich");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "SandwichId",
                table: "Sandwich");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sandwich",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Sandwich",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sandwich",
                table: "Sandwich",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sandwich_SupplierId",
                table: "Sandwich",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sandwich_Supplier_SupplierId",
                table: "Sandwich",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SandwichIngredients_Ingredient_SandwichId",
                table: "SandwichIngredients",
                column: "SandwichId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandwichIngredients_Sandwich_SandwichId",
                table: "SandwichIngredients",
                column: "SandwichId",
                principalTable: "Sandwich",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sandwich_Supplier_SupplierId",
                table: "Sandwich");

            migrationBuilder.DropForeignKey(
                name: "FK_SandwichIngredients_Ingredient_SandwichId",
                table: "SandwichIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_SandwichIngredients_Sandwich_SandwichId",
                table: "SandwichIngredients");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sandwich",
                table: "Sandwich");

            migrationBuilder.DropIndex(
                name: "IX_Sandwich_SupplierId",
                table: "Sandwich");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sandwich");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Sandwich");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "SandwichId",
                table: "Sandwich",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sandwich",
                table: "Sandwich",
                column: "SandwichId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_SandwichIngredients_Ingredient_SandwichId",
                table: "SandwichIngredients",
                column: "SandwichId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandwichIngredients_Sandwich_SandwichId",
                table: "SandwichIngredients",
                column: "SandwichId",
                principalTable: "Sandwich",
                principalColumn: "SandwichId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
