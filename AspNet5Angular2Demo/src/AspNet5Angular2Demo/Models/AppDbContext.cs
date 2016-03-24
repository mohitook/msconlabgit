using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Angular2Demo.Models
{
    public class AppDbContext: IdentityDbContext
    {

        //adatbázis codefirst a kellő beállításokkal
        public DbSet<Wowclass> Wowclasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\V11.0;Database=AspNet5Angular2Demo;Trusted_Connection=true;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
