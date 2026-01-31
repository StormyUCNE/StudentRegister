using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegister.Migrations
{
    /// <inheritdoc />
    public partial class TiposPuntos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposPuntos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPuntos = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPuntos", x => x.TipoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposPuntos");
        }
    }
}
