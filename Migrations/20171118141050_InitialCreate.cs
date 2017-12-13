using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CademeucarroApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsStolen = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Plate = table.Column<string>(type: "TEXT", nullable: true),
                    StolenOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
