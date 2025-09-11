using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedProductsAndLotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total_Productos",
                table: "Inventarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total_Productos",
                table: "Inventarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
