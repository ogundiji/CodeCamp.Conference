using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCamp.Conference.Persistence.Migrations
{
    public partial class adjustEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Speakers_SpeakerId1",
                table: "Talks");

            migrationBuilder.DropIndex(
                name: "IX_Talks_SpeakerId1",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "SpeakerId1",
                table: "Talks");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeakerId",
                table: "Talks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TalkId",
                table: "Camps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakerId",
                table: "Talks",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talks_Speakers_SpeakerId",
                table: "Talks");

            migrationBuilder.DropIndex(
                name: "IX_Talks_SpeakerId",
                table: "Talks");

            migrationBuilder.DropColumn(
                name: "TalkId",
                table: "Camps");

            migrationBuilder.AlterColumn<string>(
                name: "SpeakerId",
                table: "Talks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SpeakerId1",
                table: "Talks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakerId1",
                table: "Talks",
                column: "SpeakerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Talks_Speakers_SpeakerId1",
                table: "Talks",
                column: "SpeakerId1",
                principalTable: "Speakers",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
