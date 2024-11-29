using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumntosheepcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_Zero_Three",
                table: "SheepCategoryEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SheepCategoryEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SheepCategoryEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_Zero_Three",
                table: "SheepCategoryEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 8);
        }
    }
}
