
using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class Comment : BaseEntity 
	{
		public required string UserId { get; set; }
		public required int PostId { get; set; }
		public required string TextContent { get; set; }
		public int? ParentCommentId { get; set; }
		public byte? Image {  get; set; }
		[ForeignKey("ParentCommentId")]
		public Comment? ParentComment { get; set; }
		[ForeignKey("PostId")]
		public Post Post { get; set; }
		public ICollection<CommentLike>? CommentLikes { get; set; }
		public ICollection<Comment>? CommentsReplies { get; set; }
	}
}
