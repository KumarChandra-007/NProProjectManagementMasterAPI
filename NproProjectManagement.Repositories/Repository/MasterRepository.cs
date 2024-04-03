using NproProjectManagement.Common.Entities;
using Repositories.Interface;

namespace Repositories.Repository
{
    public class MasterRepository : IMasterRepository
    {
        public readonly NproContext _context;
        public MasterRepository(NproContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRoleAsync()
        {
            var role = _context.Roles.Where(r => r.IsActive == true).ToList();
            if (role != null)
            {
                return role;
            }
            return null;
        }

        public async Task<List<Status>> GetStatusAsync()
        {
            var status = _context.Statuses.Where(s => s.IsActive == true).ToList();
            if (status != null)
            {
                return status;
            }
            return null;
        }
    }
}