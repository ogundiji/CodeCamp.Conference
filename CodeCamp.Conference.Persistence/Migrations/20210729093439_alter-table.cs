using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCamp.Conference.Persistence.Migrations
{
    public partial class altertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "TalkId",
                table: "Camps");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeakerId",
                table: "Talks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeakerId",
                table: "Talks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TalkId",
                table: "Camps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
