using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Deli.Models._Enums;

namespace Deli.Models
{
    public class User
    {
        public User() { }

        public User(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            City = user.City;
            State = user.State;
            Zip = user.Zip;
            UserName = user.UserName;
            Password = user.Password;
            PaymentType = user.PaymentType;
            CardType = user.CardType;
            CardNumber = user.CardNumber;
            ExpDate = user.ExpDate;
            CVC = user.CVC;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public PaymentType? PaymentType { get; set; }
        public CardType? CardType { get; set; }
        public long? CardNumber { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? CVC { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}
