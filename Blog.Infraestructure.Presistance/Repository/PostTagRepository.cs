using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class PostTagRepository : BaseRepository<PostTag>, IPostTagRepository
	{
        private readonly ApplicationContext _context;

        public PostTagRepository(ApplicationContext context) : base(context) => _context = context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postId">postId</param>
        /// <param name="tagId">tagId</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int postId, int tagId)
        {
            PostTag postTagToDelete = await _context.PostTags.FirstOrDefaultAsync(b => b.PostId == postId && b.TagId == tagId);

            return postTagToDelete != null ? await base.DeleteAsync(postTagToDelete.Id) : false;
        }
    }
}
