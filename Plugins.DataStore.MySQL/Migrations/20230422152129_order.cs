using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Orders",
                newName: "CustomerPhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShoppingCartProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DaysOfRenting",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDay",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupDay",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDiscount",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_OrderId",
                table: "ShoppingCartProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_Orders_OrderId",
                table: "ShoppingCartProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_Orders_OrderId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartProducts_OrderId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DaysOfRenting",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDay",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupDay",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerPhoneNumber",
                table: "Orders",
                newName: "Adress");

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
