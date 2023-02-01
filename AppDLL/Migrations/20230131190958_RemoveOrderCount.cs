using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDLL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
