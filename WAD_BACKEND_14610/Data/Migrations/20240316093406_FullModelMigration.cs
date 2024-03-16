using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_BACKEND_14610.Data.Migrations
{
    public partial class FullModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "EventManagements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Organizer",
                table: "EventManagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "EventManagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EventAttendeess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventAttendeess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "EventAttendeess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendeess_EventId",
                table: "EventAttendeess",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendeess_EventManagements_EventId",
                table: "EventAttendeess",
                column: "EventId",
                principalTable: "EventManagements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendeess_EventManagements_EventId",
                table: "EventAttendeess");

            migrationBuilder.DropIndex(
                name: "IX_EventAttendeess_EventId",
                table: "EventAttendeess");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "EventManagements");

            migrationBuilder.DropColumn(
                name: "Organizer",
                table: "EventManagements");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "EventManagements");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EventAttendeess");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventAttendeess");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "EventAttendeess");
        }
    }
}
