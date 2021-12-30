using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityExploration.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CareerStartedDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FullName { get; set; }
    }
}
