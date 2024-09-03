

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class CommentLike : IBaseSoftDeleteEntity
	{
		public string UserId { get; set; }
		public int CommentId { get; set; }
		public Comment Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
