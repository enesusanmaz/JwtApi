using Dapper;
using Me.DataAccess.Abstract;
using Me.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Me.DataAccess.Concrete.Dapper
{
    public class DpUserRepository : IUserRepository
    {
        #region Db Configuration
        private readonly string connectionString;
        public DpUserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("DBInfo:ElephantSqlConnectionString").Value;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
        #endregion

        #region CRUD
        public int Add(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("INSERT INTO users (password_hash,password_salt,user_name) VALUES(@password_hash,@password_salt,@user_name)", item);
            }
        }

        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }

        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<User>("SELECT * FROM users WHERE id = @Id", new { Id = id });
            }
        }

        public int Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("DELETE FROM users WHERE id=@Id", new { Id = id });
            }
        }

        public int Update(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("UPDATE users SET password_hash = @password_hash,  password_salt  = @password_salt, user_name= @user_name WHERE id = @id", item);
            }
        }
        #endregion

        #region Custom Operations
        public User FindByUserName(string userName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE user_name = @UserName", new { UserName = userName }).FirstOrDefault();
            }
        }
        #endregion
    }
}
