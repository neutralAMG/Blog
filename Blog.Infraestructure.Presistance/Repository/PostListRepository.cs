using Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;


namespace Blog.Infraestructure.Presistance.Repository
{
    public class PostListRepository : BaseRepository<PostList>, IPostListRepository
	{
		public PostListRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
