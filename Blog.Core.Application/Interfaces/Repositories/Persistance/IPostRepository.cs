﻿using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Interfaces.Repositories.Persistance
{
	public interface IPostRepository : IBaseCompleteRepository<Post>
	{
		Task<IEnumerable<Post>> GetByTagIdAsync(int tagId);
	}
}