
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.UserData.UserList.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserList.Models;
using Blog.Core.Application.Features.Application.UserData.UserList.Validator;

namespace Blog.Core.Application.Features.Application.UserData.UserList
{
    public class UserListService : BaseCompleteService<SaveUserListModel, UserListModel, Domain.Entities.UserList>
    {
        public UserListService(IUserListRepository userListRepository, IMapper mapper, UserListValidator validator) : base(userListRepository, mapper, validator)
        {
        }
    }
}
