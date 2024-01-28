using ReactApp_v9.Models;

namespace ReactApp_v9.Services.Interfaces
{
    public interface IPhoneDbService
    {
        public IEnumerable<Phone> GetAllPhone();
        public Phone GetPhoneById(int id);
        public void AddPhone(Phone newPhone);
        public void DeletePhoneById(int id);
    }
}
