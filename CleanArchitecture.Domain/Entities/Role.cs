using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public sealed class Role : IdentityRole<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}
