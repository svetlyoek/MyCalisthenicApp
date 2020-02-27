namespace MyCalisthenicApp.Web.Validations
{
    public static class WebValidations
    {
        #region Contact form input validations
        public const int ContactFullNameMaxLength = 50;
        public const int ContactContentMaxLength = 500;
        #endregion

        #region Comment validations
        public const int CommentMessageMaxLength = 200;
        public const int CommentFullNameMaxLength = 50;
        #endregion

        #region Program validations
        public const int ProgramTitleMaxLength = 50;
        #endregion
    }
}
