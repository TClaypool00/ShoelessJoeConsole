using System;
using System.Collections.Generic;

namespace ShoelessJoe.DataAccess.DataModels
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            UserReplies = new HashSet<UserReplies>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<UserReplies> UserReplies { get; set; }
    }
}
