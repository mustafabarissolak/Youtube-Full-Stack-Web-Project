using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class dropRemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ProjectDescriptions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ExperienceDescriptions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AboutsMe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Skills",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ProjectDescriptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Languages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Experiences",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ExperienceDescriptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Educations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AboutsMe",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
