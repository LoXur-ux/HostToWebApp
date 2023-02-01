using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDLL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAutoInOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "AutoId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "AutoId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
