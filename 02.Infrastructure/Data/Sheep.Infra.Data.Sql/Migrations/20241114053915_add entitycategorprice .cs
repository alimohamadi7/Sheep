using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addentitycategorprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheepCategoryEntity_CategoryEntity_GroupId",
                table: "SheepCategoryEntity");

            migrationBuilder.DropColumn(
                name: "Food",
                table: "CategoryEntity");

            migrationBuilder.DropColumn(
                name: "Overhead",
                table: "CategoryEntity");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "CategoryEntity");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "SheepCategoryEntity",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SheepCategoryEntity_GroupId",
                table: "SheepCategoryEntity",
                newName: "IX_SheepCategoryEntity_CategoryId");

            migrationBuilder.CreateTable(
                name: "CategoryPriceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Food = table.Column<long>(type: "bigint", nullable: false),
                    Salary = table.Column<long>(type: "bigint", nullable: false),
                    Overhead = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPriceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryPriceEntity_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPriceEntity_CategoryId",
                table: "CategoryPriceEntity",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheepCategoryEntity_CategoryEntity_CategoryId",
                table: "SheepCategoryEntity",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheepCategoryEntity_CategoryEntity_CategoryId",
                table: "SheepCategoryEntity");

            migrationBuilder.DropTable(
                name: "CategoryPriceEntity");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SheepCategoryEntity",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_SheepCategoryEntity_CategoryId",
                table: "SheepCategoryEntity",
                newName: "IX_SheepCategoryEntity_GroupId");

            migrationBuilder.AddColumn<long>(
                name: "Food",
                table: "CategoryEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Overhead",
                table: "CategoryEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Salary",
                table: "CategoryEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_SheepCategoryEntity_CategoryEntity_GroupId",
                table: "SheepCategoryEntity",
                column: "GroupId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
