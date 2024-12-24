

namespace Blog.Core.Application.Features.Application.Pots.PostTags.Models
{
    public class SavePostTagModel
    {
        public required int PostId { get; set; }
        public required int TagId { get; set; }
    }
}
