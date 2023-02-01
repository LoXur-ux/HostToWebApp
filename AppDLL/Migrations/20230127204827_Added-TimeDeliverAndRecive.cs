using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDLL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeDeliverAndRecive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeTeDeliver",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeToRecive",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeTeDeliver",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TimeToRecive",
                table: "Orders");
        }
    }
}
