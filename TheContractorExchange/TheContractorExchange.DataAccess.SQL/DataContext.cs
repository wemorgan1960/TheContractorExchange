using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContractorExchange.Core.Models;

namespace TheContractorExchange.DataAccess.SQL
{
    public class DataContext:DbContext
    {
        public DataContext()  : base("DefaultConnection") { }

            public DbSet<Contractor> Contractors { get; set; }

    }
}
