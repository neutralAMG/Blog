

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
   public class UserFollow : BaseEntity
    {
        public required string FollowerId { get; set; }
        public required string FolloweId { get; set; }
    }
}
