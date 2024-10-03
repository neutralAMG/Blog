

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.Comments.Interfaces;
using Blog.Core.Application.Features.Application.Comments.Comments.Models;
using Blog.Core.Application.Utls.Enums;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Comments.Comments
{
    public class CommentService : BaseCompleteService<SaveCommentModel, CommentModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<CommentModel>>> GetCommentsByPostId(int postId)
        {
            if (postId <= 0)
                return ErrorTypess.ValidationMissMatch.Because("the id was ether empty or invalid");

            try
            {
                List<Comment> commentsGetted = await _commentRepository.GetCommentsByPostId(postId);

                return _mapper.Map<List<CommentModel>>(commentsGetted);
            }
            catch
            {
                return ErrorTypess.Exeption.Because("Critical error while getting the post comments");
            }
        }
    }
}
