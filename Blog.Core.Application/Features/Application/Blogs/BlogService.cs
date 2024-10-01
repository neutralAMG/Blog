

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.Interfaces;
using Blog.Core.Application.Features.Application.Blogs.Models;
using Blog.Core.Application.Utls.Enums;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Blogs
{
	public class BlogService : BaseCompleteService<SaveBlogModel, BlogModel, UserBlog>, IBlogService
	{
		private readonly IBlogRepository _blogRepository;
		private readonly IMapper _mapper;

		public BlogService(IBlogRepository blogRepository, IMapper mapper) : base(blogRepository, mapper)
		{
			_blogRepository = blogRepository;
			_mapper = mapper;
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
