﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarsDboContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarsDbo;Trusted_Connection=true");
        }

        public DbSet<Car> CarTable { get; set; }
        public DbSet<Brand> BrandTable { get; set; }
        public DbSet<Color> ColorTable { get; set; }
        


    }
}
