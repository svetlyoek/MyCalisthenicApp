using System;

namespace MyCalisthenicApp.Web.Common
{
    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";

        public const string ApplicationSendEmail = "mycalisthenicapp@gmail.com";

        public const string AdministratorFirstName = "Svetoslav";

        public const string AdministratorLastName = "Kazakov";

        public const string AdministratorReceiveEmail = "svetoslav.kazakov@outlook.com";

        public const string SubscribeEmailSubject = "MyCalisthenicApp subscribe";

        public const string SuccessfullSendOrderSubject = "MyCalisthenicApp Order #{0}";

        public const string SuccessfullSendContent = "Your order #{0} was send successfully. We will keep in touch via email or phone. Thank you!" +
             " " +
            "Order total price:{1}" +
             ", " +
            "Order status: {2}" +
            ", " +
            "Order payment status: {3}" +
             ", " +
            "Order dispatch date: {4}";

        public const string SubscribeEmailContent = "Thank you for your subscribe! You will be notified very soon...";

        public const string AdministratorSubscribeEmailSubject = "New subscribe";

        public const string AdministratorSubscribeEmailContent = "You have one new subscribe from {0}";

        public const string AdministratorPassword = "svetlyoek87";

        public const string AdministratorCardNumber = "2786908946573821";

        public const string AdministratorCardCVV = "478";

        public const int AdministratorCardExpirationYear = 2025;

        public const int AdministratorCardExpirationMonth = 07;

        public const int AdministratorCardExpirationDay = 16;

        public const int MaxFailedAccessAttempts = 10;
    }
}
