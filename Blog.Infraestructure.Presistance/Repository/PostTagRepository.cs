using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;


namespace Blog.Infraestructure.Presistance.Repository
{
    public class PostTagRepository : BaseRepository<PostTag>, IPostTagRepository
	{
		public PostTagRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
