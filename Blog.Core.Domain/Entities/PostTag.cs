

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class PostTag : BaseEntity
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
		[ForeignKey("PostId")]
		public Post Post { get; set; }
		[ForeignKey("TagId")]
		public Tag Tag { get; set; }
	}
}
