

namespace Blog.Core.Application.Features.Application.UserData.UserList.Models
{
    public class SaveUserListModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string UserId { get; set; }
    }
}
