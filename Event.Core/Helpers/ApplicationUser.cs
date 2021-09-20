using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Helpers
{
    public class ApplicationUser : IApplicationUser
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {

            var subject = this._httpContextAccessor.HttpContext
                            .User.Identities.First().Claims
                            .FirstOrDefault();

            if (subject==null) return 0;

            return Int32.Parse(subject.Value);
        }
    }
}
