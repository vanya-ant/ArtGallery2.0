namespace ArtGallery.Identity.Models
{
    public class UserOutputModel
    {
        public UserOutputModel(string token, string Id)
        {
            this.Token = token;
            this.Id = Id;
        }

        public string Token { get; }

        public string Id { get; }
    }
}
