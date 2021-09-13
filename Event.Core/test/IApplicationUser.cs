using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.test
{
    public interface IApplicationUser
    {
        int Id => this.GetUserId();

        int GetUserId();
    }
}
