namespace ArtGallery.Artists.Models
{
    using ArtGallery.Artists.Data.Models;
    using AutoMapper;

    public class ArtistDetailsModel : ArtistOutputModel
    {
        public void Mapping(Profile mapper)
               => mapper
                   .CreateMap<Artist, ArtistDetailsModel>()
                   .IncludeBase<Artist, ArtistOutputModel>();
    }
}
