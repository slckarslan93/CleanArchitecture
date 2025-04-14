using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Application.Services;
public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
}
