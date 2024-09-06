

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
   public class UserFollow : BaseEntity
    {
        public int FollowerId { get; set; }
        public int FolloweId { get; set; }
    }
}
