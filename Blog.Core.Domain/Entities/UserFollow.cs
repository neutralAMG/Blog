

using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Domain.Entities
{
   public class UserFollow : BaseEntity
    {
        public required int FollowerId { get; set; }
        public required int FolloweId { get; set; }
    }
}
