using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;


namespace Blog.Infraestructure.Presistance.Repository
{
    public class CommentLikeRepository : BaseRepository<CommentLike>, ICommentLikeRepositiory
	{
		private readonly ApplicationContext _context;

		public CommentLikeRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

        public async Task<bool> DeleteAsync(int commentId, string userId)
        {
            CommentLike commentLikeToDelete = await _context.CommentLikes.FirstOrDefaultAsync(c => c.CommentId == commentId && c.UserId == userId);

            return commentLikeToDelete != null ? await base.DeleteAsync(commentLikeToDelete.Id) : false;
        }
    }
}
