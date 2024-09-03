

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class Category : BaseEntity , IBaseUpdateAuditEntity , IBaseSoftDeleteEntity
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string LatUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        public IList<BlogCategory> BlogCategories { get; set; }

    }
}
