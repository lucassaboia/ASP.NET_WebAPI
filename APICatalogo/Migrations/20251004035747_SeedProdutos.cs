using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserindo os produtos solicitados.
            // Os campos Descricao e ImagemUrl serão inseridos como NULL.
            // Preco, Estoque e CategoriaId são obrigatórios, então foram adicionados valores de exemplo.

            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataInsercao, CategoriaId, Ativo)" +
                                 "Values('Monitor Gamer Curvo 27', NULL, 1899.90, NULL, 15, now(), 1, 1)");

            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataInsercao, CategoriaId, Ativo)" +
                                 "Values('Teclado Mecânico Sem Fio', NULL, 450.00, NULL, 30, now(), 2, 1)");

            migrationBuilder.Sql("Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataInsercao, CategoriaId, Ativo)" +
                                 "Values('Mouse Gamer RGB 16000 DPI', NULL, 275.50, NULL, 50, now(), 3, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverte a migration, apagando todos os dados da tabela.
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}
