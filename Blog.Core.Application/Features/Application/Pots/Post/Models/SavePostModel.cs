namespace Blog.Core.Application.Features.Application.Pots.Pots.Models
{
    public class SavePostModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
    }
}
