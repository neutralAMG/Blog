
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class Comment : BaseEntity 
	{
		public string UserId { get; set; }
		public string TextContent { get; set; }
		public int ParentCommentId { get; set; }
		public Comment ParentComment { get; set; }
		public IList<CommentLike> CommentLikes { get; set; }
		public IList<Comment> CommentsReplies { get; set; }
	}
}
