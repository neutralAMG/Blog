using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.UserData.UserList.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string UserId { get; set; }
        //public List<PostList>? Posts { get; set; }
    }
}
