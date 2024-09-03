

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
     public class PostList : BaseEntity
	{
		public int UserListId { get; set; }
		public int PostId {  get; set; }
		public UserList UserList {  get; set; }
		public Post Post { get; set; }
	}
}
