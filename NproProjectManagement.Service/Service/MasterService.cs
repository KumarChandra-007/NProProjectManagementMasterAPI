using Common.ViewModels;
using Repositories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class MasterService : IMasterService
    {
        public readonly IMasterRepository _masterRepository;


        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<List<StatusResponse>> GetStatusAsync()
        {
            var result = new List<StatusResponse>();
            var status = await _masterRepository.GetStatusAsync();
            if (status != null)
            {
                foreach (var item in status)
                {
                    var res = new StatusResponse();
                    res.StatusId = item.StatusId;
                    res.StatusName = item.StatusName;

                    result.Add(res);
                }
                return result;
            }
            return null;
        }

        public async Task<List<RoleResponse>> GetRoleAsync()
        {
            var result = new List<RoleResponse>();
            var role = await _masterRepository.GetRoleAsync();
            if (role != null)
            {

                foreach (var item in role)
                {
                    var res = new RoleResponse();
                    res.RoleId = item.RoleId;
                    res.RoleName = item.RoleName;

                    result.Add(res);
                }
                return result;
            }
            return null;
        }
    }
}
