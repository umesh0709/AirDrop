using Microsoft.EntityFrameworkCore.Migrations;

namespace AirDrop.Migrations
{
    public partial class addCryptoNameAndInfoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoInfo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoInfo", x => x.Name);

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoInfo");
        }
    }
}
