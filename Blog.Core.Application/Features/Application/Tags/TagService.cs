

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Tags.Interfaces;
using Blog.Core.Application.Features.Application.Tags.Models;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Tags
{
    public class TagService : BaseCompleteService<SaveTagModel, TagModel, Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper) : base(tagRepository, mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
    }
}
