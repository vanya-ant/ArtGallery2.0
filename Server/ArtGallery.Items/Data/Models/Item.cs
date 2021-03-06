﻿namespace ArtGallery.Items.Data.Models
{
    using ArtGallery.Items.Data;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public Category Category { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        [RegularExpression(DataConstants.Item.ImageUrlRegularExpression)]
        public string ImageUrl { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
