using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IMasterRepository
    {
        Task<List<Role>> GetRoleAsync();
        Task<List<Status>> GetStatusAsync();
    }
}
