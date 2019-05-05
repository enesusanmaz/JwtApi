using Me.Entities.Abstract;
using System;

namespace Me.Entities.Concrete
{
    public class Photo : IEntity
    {
        public int id { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime added_date { get; set; }
        public string public_id { get; set; }
        public int user_id { get; set; }
        public int like_count { get; set; }
        public int dislake_count { get; set; }
    }
}
