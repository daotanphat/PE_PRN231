using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class User
    {
        public User()
        {
            BorrowTransactions = new HashSet<BorrowTransaction>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime MembershipDate { get; set; }

        public virtual ICollection<BorrowTransaction> BorrowTransactions { get; set; }
    }
}
