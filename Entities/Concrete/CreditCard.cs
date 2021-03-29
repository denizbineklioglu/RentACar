using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CardNumber { get; set; }
        public string NameSurname { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
