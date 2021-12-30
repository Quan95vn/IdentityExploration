using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExploration.Authorization
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        public CustomRequirement(int year)
        {
            Year = year;
        }
        public int Year { get; set; }
    }
}
