using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class removeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "SheepCategoryEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "SheepCategoryEntity",
                type: "datetime2",
                nullable: true);
        }
    }
}
