using Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class UserFollowRepository : BaseCompleteRepository<UserFollow>, IUserFollowRepository
	{
        private readonly ApplicationContext _context;

        public UserFollowRepository(ApplicationContext context) : base(context) 
		{
            _context = context;
        }

        public async Task<bool> DeleteAsync(string followerId, string followeId)
        {
            UserFollow UserFollowToDelete = await _context.UserFollows.FirstOrDefaultAsync(b => b.FollowerId == followerId && b.FolloweId == followeId);

            return UserFollowToDelete != null ? await base.DeleteAsync(UserFollowToDelete.Id) : false;
        }
    }
}
