using BiteMeBurgers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiteMeBurgers.Context
{
    public class BancoContext : IdentityDbContext<IdentityUser>
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {    
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<LancheModel> Lanches { get; set; }
        public DbSet<CarrinhoCompraItemModel> CarrinhoCompraItens { get; set; }
        public DbSet<PedidoModel > Pedidos { get; set; }
        public DbSet<PedidoDetalheModel> PedidoDetalhes { get; set; }
    }
}
