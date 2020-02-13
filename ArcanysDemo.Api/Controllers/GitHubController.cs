using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcanysDemo.Core.BLL.Interfaces;
using ArcanysDemo.Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcanysDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : Controller
    {
        private readonly IGitHubUsersService _gitHubUsersService;

        public GitHubController(IGitHubUsersService gitHubUsersService)
        {
            _gitHubUsersService = gitHubUsersService;
        }
        [HttpPost("GetGitHubUsers")]
        public async Task<ResponseObject> GetGitHubUsers([FromBody]List<string> model)
        {
            return await _gitHubUsersService.GetGitHubUsers(model);
        }
    }
}