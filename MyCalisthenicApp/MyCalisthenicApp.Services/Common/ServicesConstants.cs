﻿namespace MyCalisthenicApp.Services.Common
{
    public static class ServicesConstants
    {
        // Shopping carts
        public const string InvalidShoppingCartForUser = "{0} does not have a shopping cart!";

        // Programs
        public const string InvalidProgram = "Program with {0} id does not exists!";

        // Products
        public const int ProductsDefaultPage = 1;
        public const int ProductsCountPerPage = 8;
        public const string InvalidProduct = "Product with {0} id does not exists!";
        public const string ProductsNewestSortEnum = "Newest";
        public const string ProductsOldestSortEnum = "Oldest";
        public const string ProductsPriceDescendingSortEnum = "PriceDescending";
        public const string ProductsPriceAscendingSortEnum = "PriceAscending";
        public const decimal ProductsDiscountPercentage = 0.10M;

        // Posts
        public const string InvalidPost = "Post with {0} id does not exists!";

        // Shopping bag
        public const int DefaultShoppingBagAddedQuantity = 1;

        // Membership
        public const string InvalidMembership = "Membership with {0} id does not exists!";

        // App discount coupon
        public const string AppDiscountCoupon = "mycalisthenicapp20";

    }
}
