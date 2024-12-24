

namespace Blog.Core.Application.Features.Application.Pots.PostLikes.Models
{
    public class SavePostLikeModel
    {
        public required string UserId { get; set; }
        public required int PostId { get; set; }
    }
}
