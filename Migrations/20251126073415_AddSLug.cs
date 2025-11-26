using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddSLug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "shop_category",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slug",
                table: "shop_category");
        }
    }
}
