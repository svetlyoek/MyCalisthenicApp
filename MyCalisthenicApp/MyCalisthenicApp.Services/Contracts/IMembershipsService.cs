namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Memberships;

    public interface IMembershipsService
    {
        Task<IEnumerable<MembershipPlanViewModel>> GetAllMembershipPlansAsync();

        Task<IList<MembershipsAdminViewModel>> GetAllMembershipsAsync();

        Task<decimal?> GetMembershipPriceByIdAsync(string id);
    }
}
