﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InscripcionAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Aspirantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Aspirantes");
        }
    }
}