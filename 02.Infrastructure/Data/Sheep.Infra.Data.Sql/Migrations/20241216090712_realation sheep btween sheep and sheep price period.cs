using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class realationsheepbtweensheepandsheeppriceperiod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SheepPricePeriodEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SheepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceSheep = table.Column<long>(type: "bigint", nullable: true),
                    Unabsorbedcosts = table.Column<long>(type: "bigint", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheepPricePeriodEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheepPricePeriodEntity_SheepEntity_SheepId",
                        column: x => x.SheepId,
                        principalTable: "SheepEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SheepPricePeriodEntity_SheepId",
                table: "SheepPricePeriodEntity",
                column: "SheepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SheepPricePeriodEntity");
        }
    }
}
