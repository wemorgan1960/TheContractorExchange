﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContractorExchange.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset CreateAT { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateAT = DateTime.Now;
        }
    }
}
