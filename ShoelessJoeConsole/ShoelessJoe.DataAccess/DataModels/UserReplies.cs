using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class UserReplies
    {
        public int ReplyManagerId { get; set; }
        public int UserId { get; set; }
        public int ReplyId { get; set; }

        public virtual Reply Reply { get; set; }
        public virtual Users User { get; set; }
    }
}
