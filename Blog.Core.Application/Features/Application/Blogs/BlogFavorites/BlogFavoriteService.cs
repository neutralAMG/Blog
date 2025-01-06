using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Models;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Validator;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Blogs.BlogFavorites
{
    public class BlogFavoriteService : BaseService<SaveBlogFavoriteModel, BlogFavorite>, IBlogFavoriteService
    {
        private readonly IBlogFavoriteRepository _blogFavoriteRepository;
        private readonly BlogFavoriteValidator _blogFavoriteValidator;

        public BlogFavoriteService(IBlogFavoriteRepository blogFavoriteRepository, IMapper mapper, BlogFavoriteValidator blogFavoriteValidator) : base(blogFavoriteRepository, mapper, blogFavoriteValidator)
        {
            _blogFavoriteRepository = blogFavoriteRepository;
            _blogFavoriteValidator = blogFavoriteValidator;
        }

        public async Task<Result> AddOrUnAddBlogToFavoriteAsync(string userId, int blogId)
        {
            if (string.IsNullOrEmpty(userId))
                ErrorTypess.ValidationMissMatch.Because("User Id can not be null");

            if (blogId <= 0)
                ErrorTypess.ValidationMissMatch.Because("Blog id was empty or invalid");

            if (await _blogFavoriteRepository.ExitsAsync(b => b.UserId == userId && b.BlogId == blogId))
            {
                bool deleteIsSuccess = await _blogFavoriteRepository.DeleteAsync(userId, blogId);
                return deleteIsSuccess ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing the blog from favorites");
            }

            return await base.SaveAsync(new()
            {
                BlogId = blogId,
                UserId = userId,
            });
        }
    }
}
