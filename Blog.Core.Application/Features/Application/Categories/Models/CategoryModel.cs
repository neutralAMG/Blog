
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Application.Features.Application.Categories.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
