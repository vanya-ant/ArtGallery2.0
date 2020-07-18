namespace ArtGallery.Artists.Models
{
    public class CreateArtistOutputModel
    {
        public CreateArtistOutputModel(string ItemId)
        {
            this.ItemId = ItemId;
        }

        public string ItemId { get; }
    }
}
