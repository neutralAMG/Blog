using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Models;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Validator;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories
{
    public class BlogCategoryService : BaseService<SaveBlogCategoryModel, BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly BlogCategoryValidator _blogCategoryValidator;

        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository, IMapper mapper, BlogCategoryValidator blogCategoryValidator) : base(blogCategoryRepository, mapper, blogCategoryValidator)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _blogCategoryValidator = blogCategoryValidator;
        }

        public async Task<Result> AddOrUnAddCategoryToBlogAsync(int blogId, int categoryId)
        {
            if (categoryId <= 0)
                ErrorTypess.ValidationMissMatch.Because("Category Id can not be null.");

            if (blogId <= 0)
                ErrorTypess.ValidationMissMatch.Because("Blog id was empty or invalid.");

            if (await _blogCategoryRepository.ExitsAsync(b => b.CategoryId == categoryId && b.BlogId == blogId))
            {
                bool deleteIsSuccess = await _blogCategoryRepository.DeleteAsync(blogId, categoryId);
                return deleteIsSuccess 
                    ? Result.Success() 
                    : ErrorTypess.OperationFaild.Because("Error while removing a category from the blog.");
            }

            return await base.SaveAsync(new()
            {
                BlogId = blogId,
                CategoryId = categoryId,
            });
        }
    }
}
