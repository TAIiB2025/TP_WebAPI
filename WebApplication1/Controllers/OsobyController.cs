using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OsobyController : ControllerBase
    {
        private readonly IOsobyService osobyService;

        public OsobyController(IOsobyService osobyService)
        {
            this.osobyService = osobyService;
        }

        //serwer/api/osoby
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<OsobaDTO> Get()
        {
            return osobyService.Get();
        }

        //serwer/api/osoby/10
        [HttpGet("{id}")]
        public OsobaDTO GetByID(int id)
        {
            return osobyService.GetByID(id);
        }

        //serwer/api/osoby
        [HttpPost]
        public void Post([FromBody] OsobaPostDTO o)
        {
            osobyService.Post(o);
        }
    }
}
