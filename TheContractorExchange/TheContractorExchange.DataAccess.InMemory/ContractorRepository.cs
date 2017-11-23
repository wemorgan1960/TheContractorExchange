using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using TheContractorExchange.Core.Models;

namespace TheContractorExchange.DataAccess.InMemory
{
    public class ContractorRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Contractor> contractors = new List<Contractor>();

        public ContractorRepository()
        {
            contractors = cache["contractors"] as List<Contractor>;
            if (contractors == null)
            {
                contractors = new List<Contractor>();
            }
        }

        public void Commit()
        {
            cache["contractors"] = contractors;
        }
        public void Insert(Contractor c)
        {
            contractors.Add(c);
        }
        public void Update(Contractor contractor)
        {
            Contractor contractorToUpdate = contractors.Find(c => c.Id == contractor.Id);
            if (contractorToUpdate != null)
            {
                contractorToUpdate = contractor;
            }
            else
            {
                throw new Exception("Contractor Not Found");
            }
        }
        public Contractor Find(string Id)
        {
            Contractor contractor = contractors.Find(c => c.Id == Id);
            if (contractor != null)
            {
                return contractor;
            }
            else
            {
                throw new Exception("Contractor Not Found");
            }

        }
        public IQueryable<Contractor> Collection()
        {
            return contractors.AsQueryable();
        }

        public void Delete(string Id)
        {
            Contractor contractorToDelete = contractors.Find(c => c.Id == Id);
            if (contractorToDelete != null)
            {
                contractors.Remove(contractorToDelete);
            }
            else
            {
                throw new Exception("Contractor Not Found");
            }
        }
    }
}
