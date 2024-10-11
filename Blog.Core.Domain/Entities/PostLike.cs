

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class PostLike : BaseEntity , IBaseSoftDeleteEntity
	{

        public required string UserId { get; set; }
        public required int PostId { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
