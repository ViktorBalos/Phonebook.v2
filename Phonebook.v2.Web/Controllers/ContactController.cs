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
using Learn.Phonebook.Web.Models.Data;
using System.Threading.Tasks;

namespace Phonebook.v2.Web.Controllers
{
    public class ContactController : Controller
    {
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

        public ActionResult Details(int? ID)
        {

            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsModel detail = new DetailsModel();
            
            using (_uow = new UnitOfWork(new PhonebookContext()))
            {
                var contact = _uow.ContactRepository.GetByID((int)ID);
                var street = _uow.StreetRepository.GetByID(contact.StreetID);
                var city = _uow.CityRepository.GetByID(street.CityID);
                var country = _uow.CountryRepository.GetByID(city.CountryID);

                detail = DetailHelper(contact, street, city, country);

            }
                        
            if (detail== null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        private DetailsModel DetailHelper(Contact contact, Street street, City city, Country country)
        {
            DetailsModel detail = new DetailsModel();

            

            detail.StreetName = street.StreetName;
            detail.CityName = city.CityName;
            detail.CountryName = country.CountryName;
            detail.ID = contact.ID;
            detail.FirstName = contact.FirstName;
            detail.LastName = contact.LastName;
            detail.PhoneNumber = contact.PhoneNumber;
            detail.Email = contact.Email;
            detail.HouseNumber = contact.HouseNumber;
            detail.CreatedBy = (contact.CreatedBy == null) ? "-" : contact.CreatedBy;
            detail.CreatedOn = ( contact.CreatedOn ==null) ? DateTime.Today :contact.CreatedOn; //nisam znao kako da resim ovo drugacije za ove datetime podatke
            detail.UpdateBy = (contact.UpdateBy == null) ? "-" : contact.UpdateBy; 
            detail.UpdatedOn = (contact.UpdatedOn == null) ? DateTime.Today : contact.UpdatedOn; //nisam znao kako da resim ovo drugacije za ove datetime podatke

            return detail;
        }

        //Route("/Contact/Create")]
        [HttpGet]
        public ActionResult AddContact()
        {
            AddContactModel model = new AddContactModel();
            return View(model);
        }

        //[Route("/Contact/Create")]
        [HttpPost]
        public async Task<ActionResult> AddContact(AddContactModel input)
        {
            if (!ModelState.IsValid)
                return null;
            Contact entity = new Contact()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                CreatedBy = User.Identity.Name.ToString(),
                CreatedOn = DateTime.Now,
                Email = input.Email,
                HouseNumber = input.HouseNumber,
                PhoneNumber = input.PhoneNumber,
                UpdateBy = User.Identity.Name.ToString(),
                UpdatedOn = DateTime.Now,
            };
            using (_uow = new UnitOfWork(new PhonebookContext()))
            {
                var country = _uow.CountryRepository.Get(c => c.CountryName == input.CountryName).FirstOrDefault();
                var city = _uow.CityRepository.Get(c => c.CountryID == country.ID && c.CityName == input.CityName).FirstOrDefault();
                var street = _uow.StreetRepository.Get(s => s.CityID == city.ID && s.StreetName == input.StreetName).FirstOrDefault();

                entity.StreetID = street.ID;
                _uow.ContactRepository.Insert(entity);
                _uow.Save();
            }
                

            return RedirectToAction(nameof(Contacts));
        }

    }
}