using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garaza",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Brojmesta = table.Column<int>(name: "Broj mesta", type: "int", nullable: false),
                    Brojnivoa = table.Column<int>(name: "Broj nivoa", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garaza", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registarskaoznaka = table.Column<string>(name: "Registarska oznaka", type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Brojtelefona = table.Column<string>(name: "Broj telefona", type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parking mesto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoziloID = table.Column<int>(type: "int", nullable: true),
                    Vremeparkiranja = table.Column<int>(name: "Vreme parkiranja", type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    GarazaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking mesto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parking mesto_Garaza_GarazaID",
                        column: x => x.GarazaID,
                        principalTable: "Garaza",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parking mesto_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parking mesto_GarazaID",
                table: "Parking mesto",
                column: "GarazaID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking mesto_VoziloID",
                table: "Parking mesto",
                column: "VoziloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking mesto");

            migrationBuilder.DropTable(
                name: "Garaza");

            migrationBuilder.DropTable(
                name: "Vozilo");
        }
    }
}
