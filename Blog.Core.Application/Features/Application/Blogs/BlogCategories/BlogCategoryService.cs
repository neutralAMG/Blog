using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Models;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories
{
    public class BlogCategoryService : BaseService<SaveBolgCategoryModel, BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository, IMapper mapper) : base(blogCategoryRepository, mapper)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<Result> AddOrUnAddCategoryToBlogAsync(int blogId, int categoryId)
        {
            if (categoryId <= 0)
                ErrorTypess.ValidationMissMatch.Because("User Id can not be null");

            if (blogId <= 0)
                ErrorTypess.ValidationMissMatch.Because("Book id was empty or invalid");

            if (await _blogCategoryRepository.ExitsAsync(b => b.CategoryId == categoryId && b.BlogId == blogId))
            {
                bool deleteIsSuccess = await _blogCategoryRepository.DeleteAsync(blogId, categoryId);
                return deleteIsSuccess ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing a category from the blog ");
            }

            return await base.SaveAsync(new()
            {
                BlogId = blogId,
                CategoryId = categoryId,
            });
        }
    }
}
