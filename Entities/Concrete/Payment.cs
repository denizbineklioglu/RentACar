using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public string NameSurname { get; set; }
        public char CardNo { get; set; }
        public string  ExpirationDate { get; set; }
        public string  Cvc { get; set; }
    }
}
