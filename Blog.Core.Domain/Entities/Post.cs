using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class Post : BaseEntity, IBaseSoftDeleteEntity ,    IBaseUpdateAuditEntity
	{
        public int BlogId  { get; set; }
        [StringLength(70)]
        public required string Title { get; set; }
        public required string PostContent { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
		public string? LastUpdatedBy { get; set; }

		[ForeignKey("BlogId")]
        public UserBlog Blog { get; set; }
        public IReadOnlyCollection<Comment>? Comments { get; set; }
        public IReadOnlyCollection<PostLike>? PostLikes { get; set; }
        public IReadOnlyCollection<PostList>? PostLists { get; set; }
        public IReadOnlyCollection<PostTag>? PostTags { get; set; }
    }
}
