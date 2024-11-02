using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ConfigModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 22, 59, 56, 645, DateTimeKind.Utc).AddTicks(6103));

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("56f740ff-40fd-47d3-a565-ffc9418544cb"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 22, 59, 56, 645, DateTimeKind.Utc).AddTicks(6100));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 22, 9, 49, 868, DateTimeKind.Utc).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("56f740ff-40fd-47d3-a565-ffc9418544cb"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 22, 9, 49, 868, DateTimeKind.Utc).AddTicks(6939));
        }
    }
}
