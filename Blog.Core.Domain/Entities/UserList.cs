
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class UserList : BaseEntity
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public string UserId { get; set; }
		public IList<PostList> Posts { get; set; }
	}
}
