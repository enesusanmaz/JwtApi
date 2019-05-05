using Me.Business.Abstract;
using Me.DataAccess.Abstract;
using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Me.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public int Add(User item)
        {
           return _userRepository.Add(item);
        }

        public IEnumerable<User> FindAll()
        {
            return _userRepository.FindAll();
        }

        public User FindByID(int id)
        {
            return _userRepository.FindByID(id);
        }

        public User FindByUserName(string userName)
        {
            return _userRepository.FindByUserName(userName);
        }

        public int Remove(int id)
        {
           return _userRepository.Remove(id);
        }

        public int Update(User item)
        {
           return _userRepository.Update(item);
        }
    }
}
