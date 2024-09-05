

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Domain.Entities
{
	public class Tag : BaseEntity, IBaseUpdateAuditEntity, IBaseSoftDeleteEntity
	{
        [StringLength(70)]
        public string Name { get; set; }
		[StringLength(180)]
		public string Description { get; set; }
        public string LatUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }

        public IList<PostTag> PostTags { get; set; }
        public IList<BlogCategory> BogTags { get; set; }
    }
}
