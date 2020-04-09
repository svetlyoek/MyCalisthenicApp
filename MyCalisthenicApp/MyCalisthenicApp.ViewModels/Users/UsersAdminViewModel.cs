namespace MyCalisthenicApp.ViewModels.Users
{
    using System;

    public class UsersAdminViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool HasMembership { get; set; }

        public bool HasCoupon { get; set; }

        public bool HasSubscribe { get; set; }

        public DateTime? MembershipExpirationDate { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
