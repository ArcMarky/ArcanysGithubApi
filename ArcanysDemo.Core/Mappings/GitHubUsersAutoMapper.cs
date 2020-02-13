using ArcanysDemo.Core.Models;
using ArcanysDemo.Core.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.Mappings
{
    public class GitHubUsersAutoMapper : Profile
    {
        public GitHubUsersAutoMapper()
        {
            CreateMap<GitHubUsers, GitHubUsersDto>();
            CreateMap<GitHubUsersDto, GitHubUsers>();
        }
    }
}
