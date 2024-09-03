

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
	public class Blog : BaseEntity , IBaseSoftDeleteEntity
	{
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<BlogFavorite> BlogFavorites { get; set; }
        public IList<BlogCategory> BlogCategories { get; set; }

    }
}
