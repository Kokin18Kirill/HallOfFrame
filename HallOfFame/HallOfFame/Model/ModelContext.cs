using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HallOfFame.Model
{
    public class ModelContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public ModelContext()
        {

        }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AM8V2BP;Database=NSTDB;Trusted_Connection=True;");
            }
        }

        private static ModelContext context;
        public static ModelContext GetContext()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
            return context;
        }
    }
}
