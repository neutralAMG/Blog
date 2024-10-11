

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Domain.Entities
{
	public class Category : BaseEntity , IBaseUpdateAuditEntity , IBaseSoftDeleteEntity
	{
        [StringLength(70)]
        public required string Name { get; set; }
        [StringLength(180)]
        public required string Description { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        public ICollection<BlogCategory>? BlogCategories { get; set; }

    }
}
