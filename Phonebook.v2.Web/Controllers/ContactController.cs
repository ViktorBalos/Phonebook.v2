using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phonebook.V2.DataAccess;
using Phonebook.v2.DataAccess.UnitOfWork;
using Phonebook.v2.Web.Models;
using System.Net;
using Phonebook.V2.Data;

namespace Phonebook.v2.Web.Controllers
{
    public class ContactController : Controller
    {
        //private static PhonebookContext _db = new PhonebookContext();
        private UnitOfWork _uow;

        // GET: Contact
        [HttpGet]
        public ActionResult Contacts()
        {
            List<ContactModel> model = new List<ContactModel>();
            using (_uow = new UnitOfWork(new PhonebookContext()))
            {
                var data = _uow.ContactRepository.Get(null, null, null);

                foreach (var item in data)
                {
                    ContactModel contact = new ContactModel()
                    {
                        ID = item.ID,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber
                    };
                    model.Add(contact);
                }
            }          
            return View(model);
        }

        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contactToDelete = new Contact();
            using (_uow = new UnitOfWork(new PhonebookContext())) 
            {
                contactToDelete = _uow.ContactRepository.GetByID((int)ID);
            }
            
            if (contactToDelete == null)
            {
                return HttpNotFound();
            }
            return View(contactToDelete);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (_uow = new UnitOfWork(new PhonebookContext()))
            {
                var contact = _uow.ContactRepository.GetByID(id);
                _uow.ContactRepository.Delete(contact);
                _uow.ContactRepository.Save();
            }
            return RedirectToAction(nameof(Contacts));
        }

        public ActionResult Details(int? id)
        {
            PhonebookContext _db = new PhonebookContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contacts = _db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }




    }
}