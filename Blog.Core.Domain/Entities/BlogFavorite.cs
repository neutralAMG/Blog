

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class BlogFavorite : BaseEntity
	{
		public string UserId { get; set; }
		public int BlogId { get; set; }

		public Blog Blog { get; set; }
	}
}
