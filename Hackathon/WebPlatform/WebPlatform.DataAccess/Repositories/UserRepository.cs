using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using WebPlatform.DataAccess.Entities;

namespace WebPlatform.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public UserEntity GetUserById(Guid userId)
        {
            return _connection.QueryFirstOrDefault<UserEntity>("SELECT * FROM Users WHERE UserId=@UserId",
                new {UserId = userId});
        } 
    }
}
