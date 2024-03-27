using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Service;

namespace NproProjectManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        public readonly IMasterService _masterService;
        public MasterController(IMasterService masterService) 
        {
            _masterService = masterService;
        }

        [HttpGet]
        [Route("GetRoleAsync")]
        public async Task<IActionResult> GetRoleAsync()
        {
            var result = await _masterService.GetRoleAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStatusAsync")]
        public async Task<IActionResult> GetStatusAsync()
        {
            var result = await _masterService.GetStatusAsync();
            return Ok(result);
        }

    }
}
