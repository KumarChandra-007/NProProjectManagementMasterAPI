using NproProjectManagement.Common.Entities;

namespace Repositories.Interface
{
    public interface IMasterRepository
    {
        Task<List<Role>> GetRoleAsync();
        Task<List<Status>> GetStatusAsync();
    }
}
