
namespace Blog.Core.Application.Features.Application.UserData.UserFollow.Models
{
    public class SaveUserFollowModel
    {
        public required int FollowerId { get; set; }
        public required int FolloweId { get; set; }
    }
}
