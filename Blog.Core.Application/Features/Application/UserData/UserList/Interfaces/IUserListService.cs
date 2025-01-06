

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.UserData.UserList.Models;

namespace Blog.Core.Application.Features.Application.UserData.UserList.Interfaces
{
    internal interface IUserListService : IBaseCompleteService<SaveUserListModel, UserListModel>
    {
    }
}
