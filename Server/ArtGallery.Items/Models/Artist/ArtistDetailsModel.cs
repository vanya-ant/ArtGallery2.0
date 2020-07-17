namespace ArtGallery.Items.Models
{
    using AutoMapper;

    public class ArtistDetailsModel : ArtistOutputModel
    {
        public void Mapping(Profile mapper)
               => mapper
                   .CreateMap<ArtGallery.Items.Data.Models.Artist, ArtistDetailsModel>()
                   .IncludeBase<ArtGallery.Items.Data.Models.Artist, ArtistOutputModel>();
    }
}
