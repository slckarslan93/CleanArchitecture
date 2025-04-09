using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public sealed class User : IdentityUser<string>
{
    public User()
    {
        Id = Guid.NewGuid().ToString(); 
    }

    public string FullName { get; set; }
}
