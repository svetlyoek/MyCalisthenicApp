namespace MyCalisthenicApp.Services.Common
{
    public static class ServicesConstants
    {
        // Addresses
        public const string InvalidAddress = "Address does not exists!";
        public const string InvalidCity = "City does not exists!";
        public const string InvalidAddressId = "Address with {0} id does not exists!";

        // Shopping carts
        public const string InvalidShoppingCartForUser = "{0} does not have a shopping cart!";

        // Comments
        public const string InvalidComment = "Comment does not exists!";
        public const string InvalidCommentId = "Comment with {0} id does not exists!";

        // Cities
        public const string InvalidCityId = "City with {0} does not exists!";

        // Exercises
        public const string InvalidExercise = "Exercise does not exists!";
        public const string InvalidExerciseId = "Exercise with {0} id does not exists!";

        // Images
        public const string InvalidImageId = "Image with {0} id does not exists!";
        public const string InvalidImage = "Image does not exists!";

        // Users
        public const string InvalidUser = "User does not exists!";
        public const string InvalidUserId = "User with {0} id does not exists!";

        // Programs
        public const string InvalidProgramId = "Program with {0} id does not exists!";
        public const string InvalidProgram = "Program does not exists!";
        public const string BeginnerCategoryName = "Beginner";
        public const string IntermediateCategoryName = "Intermediate";
        public const string InvalidProgramCategoryId = "Program category with {0} id does not exists!";

        // Products
        public const int ProductsDefaultPage = 1;
        public const int ProductsCountPerPage = 8;
        public const string InvalidProductId = "Product with {0} id does not exists!";
        public const string InvalidProduct = "Product does not exists!";
        public const string ProductsNewestSortEnum = "Newest";
        public const string ProductsOldestSortEnum = "Oldest";
        public const string ProductsPriceDescendingSortEnum = "PriceDescending";
        public const string ProductsPriceAscendingSortEnum = "PriceAscending";
        public const decimal ProductsDiscountPercentage = 0.10M;

        // Posts
        public const int PostsDefaultPage = 1;
        public const int PostsCountPerPage = 9;
        public const string InvalidPostId = "Post with {0} id does not exists!";
        public const string InvalidPost = "Post  does not exists!";

        // Shopping bag
        public const int DefaultShoppingBagAddedQuantity = 1;

        // Membership
        public const string InvalidMembershipId = "Membership with {0} id does not exists!";
        public const string InvalidMembership = "Membership does not exists!";

        // Orders
        public const string InvalidOrder = "Order does not exists!";
        public const string InvalidOrderId = "Order with {0} id does not exists!";

        // Order-products
        public const string InvalidOrderProduct = "Order-product does not exists!";
        public const string InvalidOrderProductId = "Order-product with {0} id does not exists!";

        // Suppliers
        public const string InvalidSupplierId = "Supplier with {0} id does not exists!";

        // App discount coupon
        public const string AppDiscountCoupon = "mycalisthenicapp20";

    }
}
