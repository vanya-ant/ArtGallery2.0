namespace ArtGallery.Items.Data
{
    internal class DataConstants
    {
        public class Categories
        {
            public const int MaxNameLength = 30;
        }

        public class Artist
        {
            public const int MinNameLength = 2;
            public const string EmailRegularExrpession = @"/^\S+@\S+\.\S+$/";
            public const int MinImageUrlLength = 6;
            public const string ImageUrlRegularExpression = @"/(https?:\/\/.*\.(?:png|jpg))/i";

        }

        public class Item
        {
            public const string ImageUrlRegularExpression = @"/(https?:\/\/.*\.(?:png|jpg))/i";
            public const int MaxDescriptionLength = 300;
            public const int MaxNameLength = 30;
            public const decimal MinPrice = 0m;
        }
    }
}

