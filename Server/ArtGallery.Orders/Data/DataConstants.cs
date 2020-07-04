namespace ArtGallery.Orders.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DataConstants
    {
        public class OrderItem
        {
            public const int MaxNameLength = 30;
            public const decimal MinPrice = 0m;
            public const int MinQuantity = 1;
            public const string ImageUrlRegularExpression = @"/(https?:\/\/.*\.(?:png|jpg))/i";
        }
    }
}
