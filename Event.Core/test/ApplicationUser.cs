using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.test
{
    public class ApplicationUser : IApplicationUser
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {

            var subject = this.httpContextAccessor.HttpContext
                            .User.Identities.First().Claims
                            .FirstOrDefault();

            return Int32.Parse(subject.Value);
        }
    }
}
