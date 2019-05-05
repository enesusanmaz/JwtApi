using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Me.DataAccess.Abstract
{
    public interface IUserRepository:IBaseRepository<User>
    {
        User FindByUserName(string userName);
    }
}
