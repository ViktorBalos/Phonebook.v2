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
        private UnitOfWork _uow = new UnitOfWork(new PhonebookContext());
        private PhonebookContext db = new PhonebookContext();
        

        // GET: Contact
        [HttpGet]
        public ActionResult Contacts()
        {
            var data = _uow.ContactRepository.Get(null, null, null);
            List<ContactModel> model = new List<ContactModel>();

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
                        
            return View(model);
        }

        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(ID);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Contacts");
        }





    }
}