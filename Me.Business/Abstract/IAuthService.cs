using Me.Dto.DataTransferObjects;
using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Me.Business.Abstract
{
    public interface IAuthService
    {
        User Register(User user, string password);
        User Login(string userName,string password);
        bool UserExists(string userName);
    }

}
