using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalyearEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalyearEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SheepEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SheepNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SheepbirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SheepshopDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SheepSellDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SheepwastedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SheepState = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheepEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheepEntity_SheepEntity_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SheepEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wages_overheadsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Salary = table.Column<long>(type: "bigint", nullable: false),
                    Overhead = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages_overheadsEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPriceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Food = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PricePerSheep = table.Column<long>(type: "bigint", nullable: false),
                    Calculated = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "SheepCategoryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SheepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveCategory = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Start_Zero_Three = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zero_ThreeCalacute = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Zero_Three = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_Three_Six = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Three_SixCalcute = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Three_Six = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_Six_Eighteen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Six_EighteenCalcute = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Six_Eighteen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_Ram_Ewe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ram_EweCalcute = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheepCategoryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheepCategoryEntity_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SheepCategoryEntity_SheepEntity_SheepId",
                        column: x => x.SheepId,
                        principalTable: "SheepEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheepFullPriceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PriceSheep = table.Column<long>(type: "bigint", nullable: true),
                    Unabsorbedcosts = table.Column<long>(type: "bigint", nullable: true),
                    SheepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheepFullPriceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheepFullPriceEntity_SheepEntity_SheepId",
                        column: x => x.SheepId,
                        principalTable: "SheepEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPriceEntity_CategoryId",
                table: "CategoryPriceEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SheepCategoryEntity_CategoryId",
                table: "SheepCategoryEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SheepCategoryEntity_SheepId",
                table: "SheepCategoryEntity",
                column: "SheepId");

            migrationBuilder.CreateIndex(
                name: "IX_SheepEntity_ParentId",
                table: "SheepEntity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SheepFullPriceEntity_SheepId",
                table: "SheepFullPriceEntity",
                column: "SheepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPriceEntity");

            migrationBuilder.DropTable(
                name: "FiscalyearEntity");

            migrationBuilder.DropTable(
                name: "SheepCategoryEntity");

            migrationBuilder.DropTable(
                name: "SheepFullPriceEntity");

            migrationBuilder.DropTable(
                name: "Wages_overheadsEntity");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.DropTable(
                name: "SheepEntity");
        }
    }
}
