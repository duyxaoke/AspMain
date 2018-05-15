using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Shared.Models
{
    public class ApplicationRole1 : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
