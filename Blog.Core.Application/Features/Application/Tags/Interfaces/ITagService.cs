
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Tags.Models;

namespace Blog.Core.Application.Features.Application.Tags.Interfaces
{
    public interface ITagService : IBaseCompleteService<SaveTagModel,TagModel>
    {
    }
}
