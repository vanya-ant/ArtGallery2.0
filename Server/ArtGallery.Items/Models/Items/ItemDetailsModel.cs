namespace ArtGallery.Items.Models
{
    using ArtGallery.Items.Data.Models;
    using AutoMapper;

    public class ItemDetailsModel : ItemOutputModel
    {
        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Item, ItemDetailsModel>()
                .IncludeBase<Item, ItemOutputModel>();
    }
}
