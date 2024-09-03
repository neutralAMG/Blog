

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class PostTag : BaseEntity
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
		public Post Post { get; set; }
		public Tag Tag { get; set; }
	}
}
