﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacIT.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCandidateApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Invited",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invited",
                table: "Applications");
        }
    }
}
