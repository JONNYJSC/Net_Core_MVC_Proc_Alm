using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class Users : BaseQuery
    {
        public Users() : base() { }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var db = GetConnection())
            {
                users = db.Query<User>(@"select * from [User]").ToList();
            }
            return users;
        }

        public BaseResult CreateUsingSQLCode(User user)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                rowsAffected = db.Execute(@"INSERT INTO [User] (Email, Balance, Age, RoleID) 
                                                 VALUES (@Email, @Balance, @Age, @RoleID)", user);
            }

            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Por favor contactanos para revisar el problema con este usuario"
            };
        }

        public BaseResult CreateUsingStoredProcedure(User user)
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<BaseResult>(@"User_AddUser", new
                {
                    user.Email,
                    user.RoleID,
                    user.Balance,
                    user.Age
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public BaseResult Update(User user)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                rowsAffected = db.Execute(@"UPDATE [User]
                                               SET Email = @Email
                                                 , RoleID = @RoleID
                                                 , IsActive = @IsActive
                                                 , Age = @Age
                                                 , Balance = @Balance
                                             WHERE ID = @ID", user);
            }

            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Por favor contactanos para revisar el problema con este usuario"
            };
        }

        public User GetByID(int ID)
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<User>(@"SELECT * FROM [User] WHERE ID = @ID", new { ID });
            }
        }

        public BaseResult EliminarUsingStoredProcedure(int ID)
        {
            try
            {
                var rowsAffected = 0;
                using (var db = GetConnection())
                {
                    //rowsAffected = db.Execute(@"User_DeleteUser @ID", new { ID });
                    rowsAffected = db.Execute(@"DELETE [User] WHERE ID = @ID", new { ID });
                }

                return new BaseResult
                {
                    Success = rowsAffected > 0,
                    Message = rowsAffected > 0 ? string.Empty : "Por favor contactanos para revisar el problema con este usuario"
                };
            }
            catch (Exception ex)
            {
                return new BaseResult { Message = ex.Message, Success = false };
            }
        }
    }
}
