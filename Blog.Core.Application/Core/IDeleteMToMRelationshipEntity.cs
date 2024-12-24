

namespace Blog.Core.Application.Core
{
    public interface IDeleteUserMToMRelationshipEntity
    {
        Task<bool> DeleteAsync(int entityId, string userId);
    }

    public interface IDeleteEntityMToMRelationshipEntity
    {
        Task<bool> DeleteAsync(int entityId1, int entityId2);
    }
}
