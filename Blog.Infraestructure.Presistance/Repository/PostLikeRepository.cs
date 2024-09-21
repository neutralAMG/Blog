using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;


namespace Blog.Infraestructure.Presistance.Repository
{
	public class PostLikeRepository : BaseRepository<PostLike>, IPostLikeRepository
	{
		public PostLikeRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
