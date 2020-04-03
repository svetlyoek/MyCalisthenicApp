namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Memberships;

    public class MembershipsService : IMembershipsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public MembershipsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MembershipPlanViewModel>> GetAllMembershipPlansAsync()
        {
            var memberships = await this.dbContext
                .Memberships
                 .Where(m => m.IsDeleted == false)
                .OrderBy(p => p.YearlyPrice)
                .ToListAsync();

            var membershipsViewModel = this.mapper.Map<IEnumerable<MembershipPlanViewModel>>(memberships);

            return membershipsViewModel;
        }

        public async Task<IList<MembershipsAdminViewModel>> GetAllMembershipsAsync()
        {
            var memberships = await this.dbContext.Memberships
                 .ToListAsync();

            var membershipsViewModel = this.mapper.Map<IList<MembershipsAdminViewModel>>(memberships);

            return membershipsViewModel;
        }

        public async Task<decimal?> GetMembershipPriceByIdAsync(string id)
        {
            var membershipPrice = await this.dbContext.Memberships
                .Where(m => m.IsDeleted == false)
                .Where(m => m.Id == id)
                .Select(m => m.YearlyPrice)
                .FirstOrDefaultAsync();

            if (membershipPrice != null)
            {
                return membershipPrice;
            }
            else
            {
                return null;
            }
        }
    }
}
