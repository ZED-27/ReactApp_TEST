using Microsoft.AspNetCore.Mvc;
using ReactApp_v9.Models;



namespace ReactApp_v9.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhonesController : Controller
    {
        static readonly List<Phone> data;
        static PhonesController()
        {
            data = new List<Phone>
            {
                new Phone ("iPhone 7", 52000),
                new Phone ("Samsung Galaxy S7",42000),
            };
        }
        [HttpGet]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> Get(int id)
        {
            if (data[id - 1] == null)
                return NotFound();
            return Ok(data[id - 1]);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Phone>> Create([FromBody]Phone newPhone)
        {
            data.Add(newPhone);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Phone>> Delete(int id) 
        {
            #region FindById
            Phone? deletePhone = null;
            foreach (Phone phone in data)
            {
                if (phone.Id == id)
                { 
                    deletePhone = phone; 
                    break; 
                }
            }
            #endregion
            if(deletePhone != null)
                  data.Remove(deletePhone);
            return Ok(data);
        }
    }
}
