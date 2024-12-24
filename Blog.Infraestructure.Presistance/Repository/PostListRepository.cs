using Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class PostListRepository : BaseRepository<PostList>, IPostListRepository
	{
        private readonly ApplicationContext _context;

        public PostListRepository(ApplicationContext context) : base(context) => _context = context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId">PostId</param>
        /// <param name="UserListId">UserListId</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int postId, int userListId)
        {
            PostList PostListToDelete = await _context.PostList.FirstOrDefaultAsync(b => b.PostId == postId && b.UserListId == userListId);

            return PostListToDelete != null ? await base.DeleteAsync(PostListToDelete.Id) : false;
        }
    }
}
