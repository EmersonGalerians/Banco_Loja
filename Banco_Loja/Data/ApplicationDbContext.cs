using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Banco.EF;

namespace Banco_Loja.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Banco.EF.Cliente> Cliente { get; set; }
        public DbSet<Banco.EF.Item_pedido> Item_pedido { get; set; }
        public DbSet<Banco.EF.Pedido> Pedido { get; set; }
        public DbSet<Banco.EF.Produto> Produto { get; set; }
    }
}
