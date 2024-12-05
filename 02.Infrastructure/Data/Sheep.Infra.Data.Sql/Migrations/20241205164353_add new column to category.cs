using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumntocategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overhead",
                table: "CategoryPriceEntity");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "CategoryPriceEntity");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "CategoryEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "CategoryEntity");

            migrationBuilder.AddColumn<long>(
                name: "Overhead",
                table: "CategoryPriceEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Salary",
                table: "CategoryPriceEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
