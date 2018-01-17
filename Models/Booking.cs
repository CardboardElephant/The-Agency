using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAgency.Models
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventFinish { get; set; }

        [StringLength(128)]
        public string Location { get; set; }

        [StringLength(1024)]
        public string Requirements { get; set; }

        [StringLength(1024)]
        public string SpecialRequests { get; set; }

        public decimal Cost { get; set; }
        public bool DepositPaid { get; set; }
        public decimal Deposit { get; set; }
        public DateTime DateDepositPaid { get; set; }
        public bool BalancePaid { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateBalancePaid { get; set; }
        public virtual Venue Venues { get; set; }
        public virtual Entertainment Entertainments { get; set; }
    }
}