using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaRopa.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes", 
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimaModificacion",
                table: "Clientes", 
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaUltimaModificacion",
                table: "Clientes");
        }
    }
}
