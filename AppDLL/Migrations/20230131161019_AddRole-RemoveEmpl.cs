using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDLL.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleRemoveEmpl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AutoDelivers");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                table: "Orders",
                newName: "EmplQRCode");

            migrationBuilder.RenameColumn(
                name: "AutoId",
                table: "Orders",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AutoId",
                table: "Orders",
                newName: "IX_Orders_EmployerId");

            migrationBuilder.AddColumn<string>(
                name: "ClientQRCode",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Humans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Humans_RoleId",
                table: "Humans",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Humans_Roles_RoleId",
                table: "Humans",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Humans_EmployerId",
                table: "Orders",
                column: "EmployerId",
                principalTable: "Humans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humans_Roles_RoleId",
                table: "Humans");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Humans_EmployerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Humans_RoleId",
                table: "Humans");

            migrationBuilder.DropColumn(
                name: "ClientQRCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Humans");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Orders",
                newName: "AutoId");

            migrationBuilder.RenameColumn(
                name: "EmplQRCode",
                table: "Orders",
                newName: "QRCode");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployerId",
                table: "Orders",
                newName: "IX_Orders_AutoId");

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mark = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HumanId = table.Column<int>(type: "integer", nullable: false),
                    Passport = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoDelivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AutoId = table.Column<int>(type: "integer", nullable: false),
                    EmployerId = table.Column<int>(type: "integer", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoDelivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoDelivers_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoDelivers_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoDelivers_AutoId",
                table: "AutoDelivers",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoDelivers_EmployerId",
                table: "AutoDelivers",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_HumanId",
                table: "Employers",
                column: "HumanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Autos_AutoId",
                table: "Orders",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id");
        }
    }
}
