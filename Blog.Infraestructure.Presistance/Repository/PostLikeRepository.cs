using Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces;
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
