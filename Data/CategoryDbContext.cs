﻿using eCommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class CategoryDbContext : DbContext 
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
