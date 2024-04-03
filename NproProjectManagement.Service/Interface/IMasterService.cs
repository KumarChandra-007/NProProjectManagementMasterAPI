using Common.ViewModels;

namespace Services.Interface
{
    public interface IMasterService
    {
        Task<List<RoleResponse>> GetRoleAsync();
        Task<List<StatusResponse>> GetStatusAsync();
    }
}
