﻿namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CommentsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateCommentAsync(string id, CommentInputViewModel commentModel)
        {
           
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsByCategoryId(string id)
        {
            var comments = await this.dbContext
                 .Comments
                 .Include(u => u.Author)
                 .Where(c => c.CategoryId == id)
                 .ToListAsync();

            var commentsViewModel = this.mapper.Map<IEnumerable<CommentViewModel>>(comments);

            return commentsViewModel;
        }
    }
}