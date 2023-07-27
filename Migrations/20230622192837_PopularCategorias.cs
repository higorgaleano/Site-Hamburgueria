using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiteMeBurgers.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) " +
                "VALUES('Burgers', 'Lanches feitos com ingredientes normais')");

            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) " +
                "VALUES('Bebidas', 'Diversos tipos de bebidas para acompanhamento do lanche')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
