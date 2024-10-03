
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Models;

namespace Blog.Core.Application.Features.Application.Comments.Comments.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public string TextContent { get; set; }
        public int ParentCommentId { get; set; }
        public int RepliesCount => CommentsReplies != null ? CommentsReplies.Count : 0;
        public int LikeCount => CommentLikes != null ? CommentLikes.Count : 0;
        public byte Image { get; set; }
        public CommentModel ParentComment { get; set; }
        public List<CommentLikeModel> CommentLikes { get; set; }
        public List<CommentModel> CommentsReplies { get; set; }
    }
}
