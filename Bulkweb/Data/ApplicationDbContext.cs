﻿using Bulkweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulkweb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id =1 ,Name ="Action", DisplayOrder =1},
               new Category { Id = 2 ,Name = "SCIFI", DisplayOrder = 1}
            );

        }
    }
}
