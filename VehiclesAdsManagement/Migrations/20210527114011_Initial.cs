using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiclesAdsManagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CenaPLN = table.Column<int>(type: "int", nullable: false),
                    Rocznik = table.Column<int>(type: "int", nullable: false),
                    RodzajPaliwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrzebiegKM = table.Column<int>(type: "int", nullable: false),
                    PojemnoscCm3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
