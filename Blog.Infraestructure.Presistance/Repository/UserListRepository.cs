using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;


namespace Blog.Infraestructure.Presistance.Repository
{
	public class UserListRepository : BaseCompleteRepository<UserList>, IUserListRepository
	{
		private readonly ApplicationContext _context;

		public UserListRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<UserList>> GetAllAsync()
		{
			return await _context.UserLists.AsSplitQuery()
				.Include(u => u.Posts).ToListAsync();
		}

		public override async Task<UserList> GetByIdAsync(int id)
		{
			return await _context.UserLists.AsSplitQuery()
				.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);
		}

		public override IQueryable<UserList> GetQueribleEntity()
		{
			return _context.UserLists.AsSplitQuery().Include(u => u.Posts);
		}

		public override async Task<bool> UpdateAsync(UserList entity)
		{
			if (!await ExitsAsync(u => u.Id == entity.Id)) return false;

			UserList userListToBeUpdated = await _context.UserLists.FindAsync(entity.Id);

			userListToBeUpdated.Name = entity.Name;
			userListToBeUpdated.Description = entity.Description;

			return await base.UpdateAsync(entity);
		}
	}
}
