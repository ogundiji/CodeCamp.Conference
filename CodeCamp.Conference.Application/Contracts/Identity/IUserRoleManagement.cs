using CodeCamp.Conference.Application.Models.Authentication;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Identity
{
    public interface IUserRoleManagement
    {
        Task <GetAllRoleResponse>ViewRole();
        Task <AssignRoleToUserResponse> AssignRoleToUser(string roleName, string userId);
        Task<GetUserWithRoleResponse> GetUserWithRole(string userId); 
    }
}
