namespace ArtGallery.Statistics.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Statistics
    {
        public Statistics()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public int TotalItems { get; set; }

    }
}
