using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ConfigModels4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TheTask",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 23, 44, 37, 80, DateTimeKind.Utc).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("56f740ff-40fd-47d3-a565-ffc9418544cb"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 23, 44, 37, 80, DateTimeKind.Utc).AddTicks(623));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TheTask",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 23, 39, 4, 121, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "TheTask",
                keyColumn: "Id",
                keyValue: new Guid("56f740ff-40fd-47d3-a565-ffc9418544cb"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 23, 39, 4, 121, DateTimeKind.Utc).AddTicks(4930));
        }
    }
}
