

using Blog.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Application.Features.Application.Comments.Comments.Models
{
    public class SaveCommentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string TextContent { get; set; }
        public int ParentCommentId { get; set; }
        public byte Image { get; set; }
 
    }
}
