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
    [Route("/[controller]")]
    [ApiController]
    public class GitHubController : Controller
    {
        private readonly IGitHubUsersService _gitHubUsersService;

        public GitHubController(IGitHubUsersService gitHubUsersService)
        {
            _gitHubUsersService = gitHubUsersService;
        }
        [HttpGet]
        public async Task<IActionResult> GitHubUsers(string model)
        {
            if (!string.IsNullOrEmpty(model))
            {
                return Ok(await _gitHubUsersService.GetGitHubUsers(model));
            }
            else
            {
                return BadRequest(new { Warning = "Stack Trace : parameter string is incorrect, null or empty."});
            }
          
        }
    }
}