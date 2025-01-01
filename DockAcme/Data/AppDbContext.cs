using DockAcme.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DockAcme.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Envio> Envios { get; set; }
    }
}
