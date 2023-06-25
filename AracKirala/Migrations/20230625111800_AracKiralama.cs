using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKirala.Migrations
{
    public partial class AracKiralama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Sirket_SirketId",
                table: "Araclar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sirket",
                table: "Sirket");

            migrationBuilder.RenameTable(
                name: "Sirket",
                newName: "Sirketler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sirketler",
                table: "Sirketler",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EhliyetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KiralananAraclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AracId = table.Column<int>(type: "int", nullable: false),
                    KiralamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiralananAraclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KiralananAraclar_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KiralananAraclar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KiralananAraclar_AracId",
                table: "KiralananAraclar",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_KiralananAraclar_MusteriId",
                table: "KiralananAraclar",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_Sirketler_SirketId",
                table: "Araclar",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Sirketler_SirketId",
                table: "Araclar");

            migrationBuilder.DropTable(
                name: "KiralananAraclar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sirketler",
                table: "Sirketler");

            migrationBuilder.RenameTable(
                name: "Sirketler",
                newName: "Sirket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sirket",
                table: "Sirket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_Sirket_SirketId",
                table: "Araclar",
                column: "SirketId",
                principalTable: "Sirket",
                principalColumn: "Id");
        }
    }
}
