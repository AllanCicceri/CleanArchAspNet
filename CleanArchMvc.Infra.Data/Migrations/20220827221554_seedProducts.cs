using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into products(Name,Description,Price,Stock,Image,CategoryId)" +
             " Values('Caderno', 'Caderno espiral 20 folhas', 9.9, 10,'caderno.jpg',1)");
            migrationBuilder.Sql("Insert into products(Name,Description,Price,Stock,Image,CategoryId)" +
             " Values('Caneta', 'Caneta azul bic', 1.5, 20,'caneta.jpg',2)");
            migrationBuilder.Sql("Insert into products(Name,Description,Price,Stock,Image,CategoryId)" +
             " Values('Borracha', 'Borracha duas cores', 0.5, 15,'borracha.jpg',2)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from products");
        }
    }
}
