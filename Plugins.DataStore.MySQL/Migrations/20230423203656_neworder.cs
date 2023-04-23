using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class neworder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderedProductNames",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedProductNames",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
