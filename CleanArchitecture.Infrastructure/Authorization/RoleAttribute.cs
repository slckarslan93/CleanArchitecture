using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Infrastructure.Authorization;
public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
    {
        _role = role;
        _userRoleRepository = userRoleRepository;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        //var userId = Guid.Parse(userIdClaim.Value);
        //var hasRole = _userRoleRepository.HasRoleAsync(userId, _role).Result; //kendi generic reponu yazinca eklersin methodu 
        //if (!hasRole)
        //{
        //    context.Result = new ForbidResult();
        }
    }
}
