using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKirala.Migrations
{
    public partial class AracSirket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SirketId",
                table: "Araclar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sirket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirket", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_SirketId",
                table: "Araclar",
                column: "SirketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_Sirket_SirketId",
                table: "Araclar",
                column: "SirketId",
                principalTable: "Sirket",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_Sirket_SirketId",
                table: "Araclar");

            migrationBuilder.DropTable(
                name: "Sirket");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_SirketId",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "SirketId",
                table: "Araclar");
        }
    }
}
