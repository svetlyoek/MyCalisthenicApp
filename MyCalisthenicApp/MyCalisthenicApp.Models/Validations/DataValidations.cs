namespace MyCalisthenicApp.Models
{
    public static class DataValidations
    {
        #region Comment validations
        public const int CommentTextMaxLength = 200;
        #endregion

        #region Exercise validations
        public const int ExerciseNameMaxLength = 30;
        public const int ExerciseDescriptionMaxLength = 100;
        #endregion

        #region Program validations
        public const int ProgramTitleMaxLength = 50;
        public const int ProgramDescriptionMaxLength = 1000;

        #endregion

        #region Program category validations
        public const int ProgramCategoryNameMaxLength = 30;
        public const int ProgramCategoryDescriptionMaxLength = 500;
        #endregion


        #region Blog category validations
        public const int BlogCategoryNameMaxLength = 50;
        #endregion

        #region Post validations
        public const int PostTitleMaxLength = 100;
        #endregion

        #region Shop validations
        public const int ShopCategoryNameMaxLength = 20;
        #endregion

        #region Product validations
        public const int ProductNameMaxLength = 50;
        public const double ProductPriceMinValue = 0.01;
        public const int ProductDescriptionMaxLength = 1000;
        #endregion

        #region User validations
        public const int ApplicationUserFullNameMaxLength = 50;
        #endregion

        #region Address validations
        public const int AddressCountryNameMaxLength = 30;
        public const int AddressDescriptionMaxLength = 100;
        public const int AddressStreetMaxLength = 50;
        public const int AddressBuildingNumberMaxLength = 10;
        #endregion

        #region City validations
        public const int CityNameMaxLength = 50;
        public const int CityPostCodeMaxLength = 30;
        #endregion

        #region Order validations
        public const double OrderTotalPriceMinValue = 0.01;
        #endregion

        #region Order-Product mapping validations
        public const double OrderProductPriceMinValue = 0.01;
        #endregion

        #region User request validations
        public const int UserRequestNameMaxLength = 50;
        public const int UserRequestTitleMaxLength = 30;
        public const int UserRequestContentMaxLength = 500;
        #endregion

        #region Supplier validations
        public const int SupplierNameMaxLength = 30;
        public const double SupplierPriceMinValue = 0.01;
        #endregion

        #region Shopping cart validations
        public const int ShoppingCartNumberMaxLength = 30;
        public const int ShoppingCartCVVMaxLength = 5;
        #endregion

        #region ShoppingCart-Product mapping table validations
        public const int ShoppingCartProductQuantityMinValue = 0;
        public const int ShoppingCartProductQuantityMaxValue = 100;
        #endregion

        #region Membership validations
        public const decimal MembershipMonthlyPrice = 9.99M;
        public const decimal MembershipYearlyPrice = 89.99M;
        #endregion
    }
}
