using ArcanysDemo.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcanysDemo.Core.BLL.Interfaces
{
    public interface IGitHubUsersService
    {
        Task<ResponseObject> GetGitHubUsers(string model);
        Task<ResponseObject> FetchDataByUserName(string username);
        ResponseObject GetUserFromMemory(string userName);
        ResponseObject ValidateArrayString(List<string> model);
        Task<ResponseObject> FetchDataFromGitHub(string username);
    }
}
