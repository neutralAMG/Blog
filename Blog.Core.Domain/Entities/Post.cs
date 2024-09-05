
using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class Post : BaseEntity, IBaseSoftDeleteEntity
	{
        public int BlogId  { get; set; }
        [StringLength(70)]
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        [ForeignKey("BlogId")]
        public UserBlog Blog { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<PostLike> PostLikes { get; set; }
        public IList<PostList> PostLits { get; set; }
        public IList<PostTag> PostTags { get; set; }
    }
}
