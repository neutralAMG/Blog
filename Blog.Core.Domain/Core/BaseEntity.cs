

namespace Blog.Infraestructure.Identity.Core
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
	public interface IBaseUpdateAuditEntity
	{
        public string LastUpdatedBy { get; set; }
    }
	public interface IBaseSoftDeleteEntity
	{
		public bool IsDeleted { get; set; }
		public string DeletedBy { get; set; }
		public DateTime DeleteTime { get; set; }
	}



}
