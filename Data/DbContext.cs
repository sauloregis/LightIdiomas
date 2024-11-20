using LightIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LightIdiomas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adicione aqui as tabelas do banco como DbSet
        public DbSet<Clientes> Clientes { get; set; }
    }
}
