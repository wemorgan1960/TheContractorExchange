using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheContractorExchange.Core.Models;
using TheContractorExchange.DataAccess.InMemory;
using TheContractorExchange.Core.Contracts;

namespace TheContractorExchange.WebUI.Controllers
{
    public class ContractorManagerController : Controller
    {
        IRepository<Contractor> context;
        public ContractorManagerController(IRepository<Contractor> contractorContext)
        {
            context = contractorContext;
        }
        // GET: ContractorManager
        public ActionResult Index()
        {
            List<Contractor> contractors = context.Collection().ToList();

            return View(contractors);
        }

        public ActionResult Create()
        {
            Contractor contractor = new Contractor();
            return View(contractor);
        }

        [HttpPost]
        public ActionResult Create(Contractor contractor)
        {
            if (!ModelState.IsValid)
            {
                return View(contractor);
            }
            else
            {
                context.Insert(contractor);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Contractor contractor = context.Find(Id);
            if (contractor==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(contractor);
            }
        }
        [HttpPost]
        public ActionResult Edit(Contractor contractor, string Id)
        {
            Contractor contractorToEdit = context.Find(Id);

            if (contractorToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(contractor);
                }

                contractorToEdit.FirstName = contractor.FirstName;
                contractorToEdit.LastName = contractor.LastName;
                contractorToEdit.PhoneNumber = contractor.PhoneNumber;
                contractorToEdit.Province = contractor.Province;
                contractorToEdit.EmailAddress = contractor.EmailAddress;
                contractorToEdit.City = contractor.City;

                return RedirectToAction("Index");

            }

        }
        public ActionResult Delete(string Id)
        {
            Contractor contractorToDelete = context.Find(Id);

            if (contractorToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(contractorToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Contractor contractorToDelete = context.Find(Id);

            if (contractorToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}