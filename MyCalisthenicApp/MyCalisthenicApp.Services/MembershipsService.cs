﻿namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Common;
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

        public async Task<MembershipAdminEditViewModel> GetMembershipByIdAsync(string id)
        {
            var membership = await this.dbContext.Memberships
                .FirstOrDefaultAsync(m => m.Id == id);

            if (membership == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidMembershipId, id));
            }

            var membershipViewModel = this.mapper.Map<MembershipAdminEditViewModel>(membership);

            return membershipViewModel;
        }

        public async Task EditMembershipAsync(MembershipAdminEditViewModel inputModel)
        {
            var membership = await this.dbContext.Memberships
               .FirstOrDefaultAsync(m => m.Id == inputModel.Id);

            if (membership == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidMembershipId, inputModel.Id));
            }

            membership.IsDeleted = inputModel.IsDeleted;

            membership.DeletedOn = inputModel.DeletedOn;

            membership.ModifiedOn = inputModel.ModifiedOn;

            membership.CreatedOn = inputModel.CreatedOn;

            membership.Name = inputModel.Name;

            membership.MonthlyPrice = inputModel.MonthlyPrice;

            membership.YearlyPrice = inputModel.YearlyPrice;

            this.dbContext.Update(membership);

            await this.dbContext.SaveChangesAsync();
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
                return 0;
            }
        }

        public async Task CreateMembershipAsync(MembershipAdminCreateViewModel inputModel)
        {
            var membership = new Membership
            {
                Name = inputModel.Name,
                MonthlyPrice = inputModel.MonthlyPrice,
                YearlyPrice = inputModel.YearlyPrice,
            };

            await this.dbContext.Memberships.AddAsync(membership);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
