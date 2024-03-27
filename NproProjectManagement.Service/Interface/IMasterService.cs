using Common.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IMasterService
    {
        Task<List<RoleResponse>> GetRoleAsync();
        Task<List<StatusResponse>> GetStatusAsync();
    }
}
