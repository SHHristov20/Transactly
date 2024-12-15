﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTag",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTag",
                table: "Users");
        }
    }
}
