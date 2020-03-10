namespace MyCalisthenicApp.ViewModels.Validations
{
    public static class WebValidations
    {
        // Contact form input validations
        public const int ContactFullNameMinLength = 10;
        public const int ContactFullNameMaxLength = 50;
        public const string InvalidContactFullNameLength = "Full name must be between {2} and {1} symbols.";
        public const int ContactTitleMinLength = 5;
        public const int ContactTitleMaxLength = 50;
        public const string InvalidContactTitleLength = "Title must be between {2} and {1} symbols.";
        public const int ContactContentMinLength = 20;
        public const int ContactContentMaxLength = 500;
        public const string InvalidContactContentLength = "Message must be between {2} and {1} symbols.";

        // Comment validations
        public const int CommentMessageMaxLength = 200;
        public const int CommentFirstNameMaxLength = 50;
        public const int CommentLastNameMaxLength = 50;

    }
}
