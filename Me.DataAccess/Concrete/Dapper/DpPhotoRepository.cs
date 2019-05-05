using Dapper;
using Me.DataAccess.Abstract;
using Me.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Me.DataAccess.Concrete.Dapper
{
    public class DpPhotoRepository : IPhotoRepository
    {
        #region Db Configuration
        private string connectionString;
        public DpPhotoRepository(IConfiguration configuration)
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
        public int Add(Photo item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("INSERT INTO photos (url,description,added_date,public_id,user_id) VALUES(@url,@description,@added_date,@public_id,@user_id)", item);
            }
        }

        public IEnumerable<Photo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Photo>("SELECT * FROM photos");
            }
        }

        public Photo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Photo>("SELECT * FROM photos WHERE id = @Id", new { Id = id });
            }
        }

        public int Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("DELETE FROM photos WHERE id=@Id", new { Id = id });
            }
        }

        public int Update(Photo item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute("UPDATE photos SET url = @url,  description  = @description, added_date = @added_date, public_id = @public_id, user_id = @user_id WHERE id = @id", item);
            }
        }
        #endregion

        #region Custom Operations

        #endregion
    }
}
