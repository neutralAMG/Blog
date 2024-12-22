﻿using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Models;

namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces
{
    public interface IBlogCategoryService : IBaseService<SaveBolgCategoryModel>
    {
        Task<Result> AddOrUnAddCategoryToBlogAsync(int BlogId, int categoryId);
    }
}