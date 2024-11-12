

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Tags.Interfaces;
using Blog.Core.Application.Features.Application.Tags.Models;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Tags
{
    public class TagService : BaseCompleteService<SaveTagModel, TagModel, Tag>, ITagService
    {
        public TagService(ITagRepository tagRepository, IMapper mapper) : base(tagRepository, mapper)
        {
        }
    }
}
