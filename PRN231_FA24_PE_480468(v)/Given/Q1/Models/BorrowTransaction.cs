using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class BorrowTransaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int CopyId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual BookCopy Copy { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
