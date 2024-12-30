
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Models;
using Blog.Core.Application.Features.Users.Account.Dto;
using Blog.Core.Domain.Enums;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Application.Utls;


namespace Blog.Core.Application.Features.Application.Blogs.Blogs
{
    public class BlogService : BaseCompleteService<SaveBlogModel, BlogModel, UserBlog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IBlogFavoriteService _blogFavoriteService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly SessionManager _sessionManager;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, IBlogFavoriteService blogFavoriteService, IBlogCategoryService blogCategoryService, SessionManager sessionManager) : base(blogRepository, mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _blogFavoriteService = blogFavoriteService;
            _blogCategoryService = blogCategoryService;
            _sessionManager = sessionManager;

        }
        public override async Task<Result> UpdateAsync(SaveBlogModel entity)
        {
            if (!await _blogRepository.ExitsAsync(b => b.Id == entity.Id && b.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The blog being updated does not belogn to the current user");

            return await base.UpdateAsync(entity);
        }
        public override async Task<Result> DeleteAsync(int id)
        {
            if (!await _blogRepository.ExitsAsync(b => b.Id == id && b.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The blog being updated does not belogn to the current user");

            return await base.DeleteAsync(id);
        }
        public async override Task<Result> SaveAsync(SaveBlogModel saveModel)
        {
            if (_sessionManager.GetUserFromSession() == null)
                return ErrorTypess.NoAutenticated.Because("There is no user log in");

            saveModel.UserId = _sessionManager.GetUserFromSession().Id;
            return await base.SaveAsync(saveModel);
        }
        public async Task<Result<List<BlogModel>>> GetByCaregoryId(int categoryId)
        {
                if (categoryId <= 0)
                    ErrorTypess.ValidationMissMatch.Because("The id was ether empty or invalid");

                List<UserBlog> blogsGetted = await _blogRepository.GetByCaregoryIdAsync(categoryId);

                return _mapper.MapSafely<List<BlogModel>>(blogsGetted);
        }

        public async Task<Result<List<BlogModel>>> GetUserBlogAsync(string userId)
        {
                if (string.IsNullOrEmpty(userId))
                    ErrorTypess.ValidationMissMatch.Because("the id was empty");

                List<UserBlog> blogsGetted = await _blogRepository.GetUserBlogAsync(userId);

                return _mapper.MapSafely<List<BlogModel>>(blogsGetted);
        }

        public async Task<Result> AddOrUnAddBlogToFavorite(string userId, int blogId) => await _blogFavoriteService.AddOrUnAddBlogToFavoriteAsync(userId, blogId);

        public async Task<Result> AddOrUnAddCategoryToBlog(int categoryId, int blogId) => await _blogCategoryService.AddOrUnAddCategoryToBlogAsync(categoryId, blogId);
    }
}
