using System;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Statistics.Data.Models
{
    public class ItemView
    {
        public ItemView()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string ItemId { get; set; }

        [Required]
        public string ArtGallleryUserId { get; set; }
    }
}
