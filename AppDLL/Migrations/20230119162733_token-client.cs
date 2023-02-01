using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDLL.Migrations
{
    /// <inheritdoc />
    public partial class tokenclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AuthTokens_Token1",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_AddithionalServices_ServiceId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "AddithionalServices");

            migrationBuilder.DropIndex(
                name: "IX_Clients_StatusId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Token1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Token1",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNamber",
                table: "Humans",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MidName",
                table: "Humans",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Humans",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Humans",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "AuthTokens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_ClientId",
                table: "AuthTokens",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthTokens_Clients_ClientId",
                table: "AuthTokens",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Services_ServiceId",
                table: "ServiceOrders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthTokens_Clients_ClientId",
                table: "AuthTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Services_ServiceId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_AuthTokens_ClientId",
                table: "AuthTokens");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AuthTokens");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNamber",
                table: "Humans",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MidName",
                table: "Humans",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Humans",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Humans",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token1",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddithionalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddithionalServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StatusId",
                table: "Clients",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Token1",
                table: "Clients",
                column: "Token1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AuthTokens_Token1",
                table: "Clients",
                column: "Token1",
                principalTable: "AuthTokens",
                principalColumn: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_AddithionalServices_ServiceId",
                table: "ServiceOrders",
                column: "ServiceId",
                principalTable: "AddithionalServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
