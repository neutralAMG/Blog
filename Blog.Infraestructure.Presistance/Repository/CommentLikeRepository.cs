using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class CommentLikeRepository : BaseRepository<CommentLike>, ICommentLikeRepositiory
	{
		private readonly ApplicationContext _context;

		public CommentLikeRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}
	}
}
