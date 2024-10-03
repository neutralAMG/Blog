
using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class Comment : BaseEntity 
	{
		public string UserId { get; set; }
		public int PostId { get; set; }
		public string TextContent { get; set; }
		public int ParentCommentId { get; set; }
		public byte Image {  get; set; }
		[ForeignKey("ParentCommentId")]
		public Comment ParentComment { get; set; }
		[ForeignKey("PostId")]
		public Post Post { get; set; }
		public IList<CommentLike> CommentLikes { get; set; }
		public IList<Comment> CommentsReplies { get; set; }
	}
}
