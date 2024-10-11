

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class PostTag : BaseEntity
	{
		public required int PostId { get; set; }
		public required int TagId { get; set; }
		[ForeignKey("PostId")]
		public Post Post { get; set; }
		[ForeignKey("TagId")]
		public Tag Tag { get; set; }
	}
}
