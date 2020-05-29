using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Reply
    {
        public Reply()
        {
            UserReplies = new HashSet<UserReplies>();
        }

        public int ReplyId { get; set; }
        public string ReplyBody { get; set; }
        public DateTime ReplyDate { get; set; }
        public int? ReplyUserId { get; set; }
        public int? CommentId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual ICollection<UserReplies> UserReplies { get; set; }
    }
}
