
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class UserList : BaseEntity
	{
		public required string Name { get; set; }
		public string? Description { get; set; }
		public required string UserId { get; set; }
		public ICollection<PostList>? Posts { get; set; }
	}
}
