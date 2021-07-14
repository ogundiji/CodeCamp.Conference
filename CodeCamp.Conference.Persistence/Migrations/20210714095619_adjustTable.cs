using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCamp.Conference.Persistence.Migrations
{
    public partial class adjustTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Talks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateDeleted",
                table: "Talks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Talks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Speakers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateDeleted",
                table: "Speakers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Speakers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Camps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateDeleted",
                table: "Camps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Camps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "dateDeleted",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "dateDeleted",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "dateDeleted",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Camps");
        }
    }
}
