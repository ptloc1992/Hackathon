using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services.User
{
    public interface IUserService
    {
        bool TrackLogin(string code);
    }
}
