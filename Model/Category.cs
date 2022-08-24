﻿using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
