

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
     public class PostList : BaseEntity
	{
		public required int UserListId { get; set; }
		public required int PostId {  get; set; }
		[ForeignKey("UserListId")]
		public UserList UserList {  get; set; }
		[ForeignKey("PostId")]
		public Post? Post { get; set; }
	}
}
