using Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class PostLikeRepository : BaseRepository<PostLike>, IPostLikeRepository
	{
        private readonly ApplicationContext _context;

        public PostLikeRepository(ApplicationContext context) : base(context) => _context = context;

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId">postId</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int postId, string userId)
        {
            PostLike PostLikeToDelete = await _context.PostLikes.FirstOrDefaultAsync(b => b.PostId == postId && b.UserId == userId);

            return PostLikeToDelete != null ? await base.DeleteAsync(PostLikeToDelete.Id) : false;
        }
    }
}
