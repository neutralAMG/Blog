

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Models;
using Blog.Core.Application.Features.Users.Account.Dto;
using Blog.Core.Application.Utls.Enums;
using Blog.Core.Application.Utls.SessionHandler;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Blog.Core.Application.Features.Application.Blogs.Blogs
{
    public class BlogService : BaseCompleteService<SaveBlogModel, BlogModel, UserBlog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponce _currentUserInfo;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, ISession session, IOptions<SessionKeys> sessionKeys) : base(blogRepository, mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _currentUserInfo = session.Get<AuthenticationResponce>(sessionKeys.Value.UserKey);
        }

        public async override Task<Result> SaveAsync(SaveBlogModel saveModel)
        {
            if (_currentUserInfo == null)
                return ErrorTypess.NoAutenticated.Because("There is no user log in");

            saveModel.UserId = _currentUserInfo.Id;
            return await base.SaveAsync(saveModel);
        }
        public async Task<Result<List<BlogModel>>> GetByCaregoryId(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                    ErrorTypess.ValidationMissMatch.Because("The id was ether empty or invalid");

                List<UserBlog> blogsGetted = await _blogRepository.GetByCaregoryIdAsync(categoryId);

                return _mapper.Map<List<BlogModel>>(blogsGetted);
            }
            catch
            {
                return ErrorTypess.Exeption.Because("Critical error while getting the blogs by category");
            }
        }

        public async Task<Result<List<BlogModel>>> GetUserBlogAsync(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    ErrorTypess.ValidationMissMatch.Because("the id was empty");

                List<UserBlog> blogsGetted = await _blogRepository.GetUserBlogAsync(userId);

                return _mapper.Map<List<BlogModel>>(blogsGetted);
            }
            catch
            {
                return ErrorTypess.Exeption.Because("Critical error while getting the user blogs");
            }
        }
    }
}
