namespace Blog.Core.Application.Features.Application.Blogs.Blogs.Models
{
    public class SaveBlogModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
