using Me.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Entities.Concrete
{
    public class User : IEntity
    {
        public int id { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public string user_name { get; set; }
    }
}
