namespace MyCalisthenicApp.ViewModels.Users
{
    using System;

    public class UserAdminEditViewModel
    {
        public string Id { get; set; }

        public bool HasMembership { get; set; }

        public DateTime? MembershipExpirationDate { get; set; }

        public bool HasCoupon { get; set; }

        public bool HasSubscribe { get; set; }
    }
}
