namespace MyCalisthenicApp.Models
{
    public static class DataValidations
    {
        // Comment validations
        public const int CommentTextMaxLength = 200;

        // Exercise validations
        public const int ExerciseNameMaxLength = 30;
        public const int ExerciseDescriptionMaxLength = 100;

        // Program validations
        public const int ProgramTitleMaxLength = 50;
        public const int ProgramDescriptionMaxLength = 1000;

        // Program category validations
        public const int ProgramCategoryNameMaxLength = 30;
        public const int ProgramCategoryDescriptionMaxLength = 500;

        // Blog category validations
        public const int BlogCategoryNameMaxLength = 50;

        // Post validations
        public const int PostTitleMaxLength = 100;

        // Shop validations
        public const int ShopCategoryNameMaxLength = 20;

        // Product validations
        public const int ProductNameMaxLength = 50;
        public const double ProductPriceMinValue = 0.01;
        public const int ProductDescriptionMaxLength = 1000;

        // User validations
        public const int ApplicationUserFirstNameMaxLength = 30;
        public const int ApplicationUserLastNameMaxLength = 30;

        // Address validations
        public const int AddressCountryNameMaxLength = 30;
        public const int AddressDescriptionMaxLength = 100;
        public const int AddressStreetMaxLength = 50;
        public const int AddressBuildingNumberMaxLength = 10;

        // City validations
        public const int CityNameMaxLength = 50;
        public const int CityPostCodeMaxLength = 30;

        // Order validations
        public const double OrderTotalPriceMinValue = 0.01;

        // Order-Product mapping validations
        public const double OrderProductPriceMinValue = 0.01;

        // User request validations
        public const int UserRequestFullNameMaxLength = 50;
        public const int UserRequestContentMaxLength = 500;

        // Supplier validations
        public const int SupplierNameMaxLength = 30;
        public const double SupplierPriceMinValue = 0.01;

        // Shopping cart validations
        public const int ShoppingCartNumberMaxLength = 30;
        public const int ShoppingCartCVVMaxLength = 5;

        // ShoppingCart-Product mapping table validations
        public const int ShoppingCartProductQuantityMinValue = 0;
        public const int ShoppingCartProductQuantityMaxValue = 100;
    }
}
