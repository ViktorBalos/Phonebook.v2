using NUnit.Framework;
using Moq;
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
