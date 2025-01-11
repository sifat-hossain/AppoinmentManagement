using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appoinments.Infrastractures.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Doctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Appointment",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Appointment");
        }
    }
}
