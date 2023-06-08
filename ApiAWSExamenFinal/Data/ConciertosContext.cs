using ApiAWSExamenFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAWSExamenFinal.Data
{
    public class ConciertosContext : DbContext
    {
        public ConciertosContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CategoriaEvento> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
