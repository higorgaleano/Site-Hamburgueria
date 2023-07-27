using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiteMeBurgers.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(Nome, preco, DescricaoCurta, DescricaoDetalhada, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId) " +
                "VALUES('Clássico Brasileiro', 19.90, 'Hambúrguer clássico', " +
                "'200g de carne bovina, alface, tomate, cebola caramelizada, queijo cheddar, molho especial, pão artesanal.', " +
                "'C:/Users/higor.galeano/Downloads/BiteMeBurgers/Classico_Brasileiro.png', " +
                "'C:/Users/higor.galeano/Downloads/BiteMeBurgers/Classico_Brasileiro.png', 1, 1, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
