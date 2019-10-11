using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services.User
{
    public class UserService: IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool TrackLogin(string code)
        {
            var result = false;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlString = @"Insert into TrackLogin(Code, LoginTime) values(@Code, @LoginTime)";
                result = connection.Execute(sqlString, new { Code = code, LoginTime = DateTime.Now }) > 0;
            }
            return result;
        }
    }
}
