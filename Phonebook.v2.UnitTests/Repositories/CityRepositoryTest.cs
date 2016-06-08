using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using Moq;
using Phonebook.V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.v2.DataAccess.UnitOfWork;
using Phonebook.V2.DataAccess;

namespace Phonebook.v2.UnitTests.Repositories
{
    [TestFixture]
    public class CityRepositoryTest
    {
        private Mock<IPhonebookContext> _context = null;
        private void Setup()
        {
            _context = new Mock<IPhonebookContext>();
        }
        [Test]
        public void GetCityTest()
        {
            Setup();
            IPhonebookContext cont = new PhonebookContext();
            UnitOfWork uow = new UnitOfWork(cont);
            var result = uow.CityRepository.Get();
            Assert.IsNotNull(result);
        }
    }
}
