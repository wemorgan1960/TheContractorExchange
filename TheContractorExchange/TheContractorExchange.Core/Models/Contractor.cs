﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContractorExchange.Core.Models
{
    public class Contractor
    {
        public string Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }


        public Contractor()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
