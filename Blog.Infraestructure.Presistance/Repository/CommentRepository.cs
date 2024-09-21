﻿using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
	public class CommentRepository : BaseCompleteRepository<Comment>, ICommentRepository
	{
		private readonly ApplicationContext _context;

		public CommentRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<Comment>> GetAllAsync()
		{
			return await _context.Comments.AsSplitQuery()
				.Include(c => c.CommentsReplies)
				.Include(c => c.CommentLikes).ToListAsync();
		}

		public override async Task<Comment> GetByIdAsync(int id)
		{
			return await _context.Comments.AsSplitQuery()
				.Include(c => c.CommentsReplies)
				.Include(c => c.CommentLikes).FirstOrDefaultAsync(c => c.Id == id);
		}

		public override IQueryable<Comment> GetQueribleEntity()
		{
			return _context.Comments.AsSplitQuery()
				.Include(c => c.CommentsReplies)
				.Include(c => c.CommentLikes);
		}

		public override async Task<bool> UpdateAsync(Comment entity)
		{
			if (!await ExitsAsync(c => c.Id == entity.Id)) return false;
			Comment commentToBeUpdated = await _context.Comments.FindAsync();

			commentToBeUpdated.TextContent = entity.TextContent;
			commentToBeUpdated.Image = entity.Image;
			

			return await base.UpdateAsync(commentToBeUpdated);
		}
	}
}