using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "SheepCategoryEntity",
                newName: "Start_Zero_Three");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "SheepCategoryEntity",
                newName: "End_Zero_Three");

            migrationBuilder.AlterColumn<int>(
                name: "ActiveCategory",
                table: "SheepCategoryEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "End_Six_Eighteen",
                table: "SheepCategoryEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End_Three_Six",
                table: "SheepCategoryEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_Six_Eighteen",
                table: "SheepCategoryEntity");

            migrationBuilder.DropColumn(
                name: "End_Three_Six",
                table: "SheepCategoryEntity");

            migrationBuilder.RenameColumn(
                name: "Start_Zero_Three",
                table: "SheepCategoryEntity",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "End_Zero_Three",
                table: "SheepCategoryEntity",
                newName: "End");

            migrationBuilder.AlterColumn<bool>(
                name: "ActiveCategory",
                table: "SheepCategoryEntity",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
