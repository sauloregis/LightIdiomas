using LightIdiomas.Entities;
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

        public DbSet<Clientes> Clientes { get; set; }
    }
}
