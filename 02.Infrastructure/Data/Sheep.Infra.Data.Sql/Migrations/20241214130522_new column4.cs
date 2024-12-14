using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class newcolumn4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountSheep",
                table: "CategoryPriceEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountSheep",
                table: "CategoryPriceEntity");
        }
    }
}
