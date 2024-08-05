using ApiProduto.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ApiProduto.Contexts
{
    public class ProdutoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        // Adicione DbSets para outras entidades conforme necessário
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= NOTW18-S19\\SQLEXPRESS; Database= produtoAPI_tarde; User Id = sa; Pwd= Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }

}
