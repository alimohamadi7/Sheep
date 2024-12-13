using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class newcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PricePerSheep",
                table: "CategoryPriceEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerSheep",
                table: "CategoryPriceEntity");
        }
    }
}
