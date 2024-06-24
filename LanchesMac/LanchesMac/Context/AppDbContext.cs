using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        // ela define as opções a serem usadas pelo o DBCONTEXT e assim define as configurações do DbContext
        //DbContextOptions carrega as informações necessarias para a configuração do mesmo
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //As propriedades DbSet vão definir quais classes eu quero que seja mapeado para gerar tabelas

        public DbSet<Categoria> Categorias { get; set; }

        // Aqui apos a sua mapeação o Entity Framework irá criar uma tabela no nome igual a mesma definida
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
    }
}
