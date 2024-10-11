

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class BlogCategory : BaseEntity
	{
		public required int BlogId { get; set; }
		public required int CategoryId {  get; set; }
		[ForeignKey("BlogId")]
		public UserBlog Blog { get; set; }
		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
