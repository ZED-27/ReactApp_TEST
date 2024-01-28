using ReactApp_v9.Data;
using ReactApp_v9.Models;
using ReactApp_v9.Services.Interfaces;

namespace ReactApp_v9.Services
{
    public class PhoneDbService : IPhoneDbService
    {
        private PhoneDbContext dbContext;
        public PhoneDbService(PhoneDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IEnumerable<Phone> GetAllPhone()
        {
            return dbContext.Phones.ToList();
        }
        public Phone GetPhoneById(int id)
        {
            var phone = dbContext.Phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
               // throw new Exception("Phone not found");
            }
            return phone;
        }
        public void AddPhone(Phone newPhone)
        {
            dbContext.Phones.Add(newPhone);
            dbContext.SaveChanges();
        }
        public void DeletePhoneById(int id)
        {
            Phone? phoneToRemove = dbContext.Phones.Find(id);
            if (phoneToRemove != null)
            {
                dbContext.Phones.Remove(phoneToRemove);
                dbContext.SaveChanges();
            }
        }
    }
}
