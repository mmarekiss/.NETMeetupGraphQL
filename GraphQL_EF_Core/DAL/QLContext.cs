using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.DAL
{
    public class QLContext : DbContext
    {
        public QLContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                    .HasData(Enumerable.Range(0, 100).Select(x => new City()
                    {
                        Id = x,
                        Name = $"City {x}"
                    }));

            modelBuilder.Entity<Person>()
                .HasData(Enumerable.Range(0, 100).Select(c =>
                 Enumerable.Range(0, 50).Select(p =>
                 new Person()
                 {
                     Id = c * 100 + p,
                     CityId = c,
                     Name = $"Person {p} in city {c}"
                 }
                 )).SelectMany(x => x));
        }

        public DbSet<Person> People { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}
