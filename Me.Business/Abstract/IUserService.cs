using Me.DataAccess.Abstract;
using Me.DataAccess.Concrete.Dapper;
using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Business.Abstract
{
    public interface IUserService : IUserRepository
    {
    }
}
