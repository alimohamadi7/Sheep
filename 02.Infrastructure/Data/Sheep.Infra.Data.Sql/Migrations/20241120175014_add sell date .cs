using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addselldate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sheepshop",
                table: "SheepEntity",
                newName: "SheepwastedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "SheepSellDate",
                table: "SheepEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SheepshopDate",
                table: "SheepEntity",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SheepSellDate",
                table: "SheepEntity");

            migrationBuilder.DropColumn(
                name: "SheepshopDate",
                table: "SheepEntity");

            migrationBuilder.RenameColumn(
                name: "SheepwastedDate",
                table: "SheepEntity",
                newName: "Sheepshop");
        }
    }
}
