using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProduct",
                newName: "ShoppingCartProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProduct_ShoppingCartId",
                table: "ShoppingCartProducts",
                newName: "IX_ShoppingCartProducts_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProducts",
                newName: "ShoppingCartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProducts_ShoppingCartId",
                table: "ShoppingCartProduct",
                newName: "IX_ShoppingCartProduct_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
