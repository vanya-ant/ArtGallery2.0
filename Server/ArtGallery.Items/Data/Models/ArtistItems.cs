namespace ArtGallery.Items.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ArtistItems
    {
        [Key]
        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        [Key]
        [Required]
        public string ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
