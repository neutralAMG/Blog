

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class CommentImage : BaseEntity
	{
		public int CommentId { get; set; }
		public string ImageUrl { get; set; }
		public Comment Comment { get; set; }
	}
}
