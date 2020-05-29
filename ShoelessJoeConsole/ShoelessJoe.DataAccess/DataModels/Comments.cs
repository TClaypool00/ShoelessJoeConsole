using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Comments
    {
        public Comments()
        {
            Reply = new HashSet<Reply>();
        }

        public int CommentId { get; set; }
        public string MessageHead { get; set; }
        public string MessageBody { get; set; }
        public DateTime CommentDate { get; set; }
        public int? CommentUserId { get; set; }

        public virtual Users CommentUser { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
