
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class Post : BaseEntity, IBaseSoftDeleteEntity
	{
        public int BlogId  { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }

        public Blog Blog { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<PostLike> PostLikes { get; set; }
        public IList<PostList> PostLits { get; set; }
        public IList<PostTag> PostTags { get; set; }
    }
}
