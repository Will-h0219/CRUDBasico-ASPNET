using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDBasico.Migrations
{
    public partial class posicion_added_jugador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Posicion",
                table: "Jugador",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "Jugador");
        }
    }
}
