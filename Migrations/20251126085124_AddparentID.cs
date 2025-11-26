using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddparentID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "parent_id",
                table: "shop_category",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "shop_category");
        }
    }
}
