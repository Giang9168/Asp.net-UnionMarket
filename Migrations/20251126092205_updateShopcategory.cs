using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionMarket.Migrations
{
    /// <inheritdoc />
    public partial class updateShopcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shop_category_shops_shop_id",
                table: "shop_category");

            migrationBuilder.DropPrimaryKey(
                name: "pk_shop_category",
                table: "shop_category");

            migrationBuilder.RenameTable(
                name: "shop_category",
                newName: "shop_categories");

            migrationBuilder.RenameIndex(
                name: "ix_shop_category_shop_id",
                table: "shop_categories",
                newName: "ix_shop_categories_shop_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "parent_id",
                table: "shop_categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_shop_categories",
                table: "shop_categories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_shop_categories_shops_shop_id",
                table: "shop_categories",
                column: "shop_id",
                principalTable: "shops",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shop_categories_shops_shop_id",
                table: "shop_categories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_shop_categories",
                table: "shop_categories");

            migrationBuilder.RenameTable(
                name: "shop_categories",
                newName: "shop_category");

            migrationBuilder.RenameIndex(
                name: "ix_shop_categories_shop_id",
                table: "shop_category",
                newName: "ix_shop_category_shop_id");

            migrationBuilder.AlterColumn<string>(
                name: "parent_id",
                table: "shop_category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_shop_category",
                table: "shop_category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_shop_category_shops_shop_id",
                table: "shop_category",
                column: "shop_id",
                principalTable: "shops",
                principalColumn: "id");
        }
    }
}
