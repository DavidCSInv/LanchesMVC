using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopulandoLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnail,ImagemUrl,IsLanchePreferido,Nome,Preco)" +
                "VALUES (1,'Pão,Hamburgues,Ovo,Presunto,Queijo e Batata Palha','Delicioso Pão de Hambúrguer com ovo frito;presunto e queijo de primeira qualidade acompanhado com batata palha',1,'https://img.freepik.com/psd-gratuitas/hamburguer-de-carne-fresca-isolado-em-fundo-transparente_191095-9018.jpg?size=626&ext=jpg','https://br.freepik.com/fotos-gratis/hamburguer-saboroso-isolado-no-fundo-branco-fastfood-de-hamburguer-fresco-com-carne-e-queijo_38117312.htm#query=hamburguer%20png&position=1&from_view=keyword&track=ais_user&uuid=12dafb0c-1f95-45ed-b4ce-46ec24ba419c',0,'Cheese Salada',12.50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
