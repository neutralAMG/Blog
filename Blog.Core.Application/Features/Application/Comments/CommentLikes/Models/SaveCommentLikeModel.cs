

namespace Blog.Core.Application.Features.Application.Comments.CommentLikes.Models
{
    public class SaveCommentLikeModel
    {
        public required string UserId { get; set; }
        public required int CommentId { get; set; }
    }
}
