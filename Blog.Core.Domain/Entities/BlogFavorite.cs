

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class BlogFavorite : BaseEntity
	{
		public string UserId { get; set; }
		public int BlogId { get; set; }
		[ForeignKey("BlogId")]
		public UserBlog Blog { get; set; }
	}
}
