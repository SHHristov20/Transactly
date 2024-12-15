﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionToken",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiry",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpiry",
                table: "Users");
        }
    }
}
