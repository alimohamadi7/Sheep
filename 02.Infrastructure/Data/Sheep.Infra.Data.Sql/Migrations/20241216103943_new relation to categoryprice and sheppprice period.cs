using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sheep.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class newrelationtocategorypriceandshepppriceperiod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryPriceId",
                table: "SheepPricePeriodEntity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SheepPricePeriodEntity_CategoryPriceId",
                table: "SheepPricePeriodEntity",
                column: "CategoryPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheepPricePeriodEntity_CategoryPriceEntity_CategoryPriceId",
                table: "SheepPricePeriodEntity",
                column: "CategoryPriceId",
                principalTable: "CategoryPriceEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheepPricePeriodEntity_CategoryPriceEntity_CategoryPriceId",
                table: "SheepPricePeriodEntity");

            migrationBuilder.DropIndex(
                name: "IX_SheepPricePeriodEntity_CategoryPriceId",
                table: "SheepPricePeriodEntity");

            migrationBuilder.DropColumn(
                name: "CategoryPriceId",
                table: "SheepPricePeriodEntity");
        }
    }
}
