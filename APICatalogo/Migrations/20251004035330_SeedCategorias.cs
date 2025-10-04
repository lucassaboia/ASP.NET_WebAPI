using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("Insert into categorias(Nome, DataInsercao, Ativo)" +
                                 "Values('Monitores', now(), 1)");

            migrationBuilder.Sql("Insert into categorias(Nome, DataInsercao, Ativo)" +
                                 "Values('Teclados', now(), 1)");

            migrationBuilder.Sql("Insert into categorias(Nome, DataInsercao, Ativo)" +
                                 "Values('Mouses', now(), 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from categorias");
        }
    }
}
