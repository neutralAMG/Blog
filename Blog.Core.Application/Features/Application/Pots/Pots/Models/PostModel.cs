using Blog.Core.Application.Features.Application.Comments.Comments.Models;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Pots.Pots.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public int CommentsCounts => Comments != null ? Comments.Count : 0;
        public int LikesCounts => PostLikes != null ? PostLikes.Count : 0;
        public List<CommentModel> Comments { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
