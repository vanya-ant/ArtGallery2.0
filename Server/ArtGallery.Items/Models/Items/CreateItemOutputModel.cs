namespace ArtGallery.Items.Models.Items
{
   public class CreateItemOutputModel
    {
        public CreateItemOutputModel(string ItemId)
        {
            this.ItemId = ItemId;
        }

        public string ItemId { get; }
    }
}
