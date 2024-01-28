using Microsoft.AspNetCore.Mvc;
using ReactApp_v9.Data;
using ReactApp_v9.Models;
using ReactApp_v9.Services.Interfaces;

namespace ReactApp_v9.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhonesController : Controller
    {
        private IPhoneDbService _phonesService;
        public PhonesController(IPhoneDbService phoneDbService)
        {
            _phonesService = phoneDbService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            var data = _phonesService.GetAllPhone();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> Get(int id)
        {
            var data = _phonesService.GetPhoneById(id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Phone>> Create([FromBody] Phone newPhone)
        {
            _phonesService.AddPhone(newPhone);
            var data = _phonesService.GetAllPhone();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Phone>> Delete(int id)
        {
            _phonesService.DeletePhoneById(id);
            var data = _phonesService.GetAllPhone();
            return Ok(data);
        }
    }
}
