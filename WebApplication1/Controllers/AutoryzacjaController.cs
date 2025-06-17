using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoryzacjaController : ControllerBase
    {
        private readonly IAutoryzacjaService _autoryzacjaService;

        public AutoryzacjaController(IAutoryzacjaService autoryzacjaService) 
        { 
            _autoryzacjaService = autoryzacjaService;
        }

        [HttpPost]
        //public LoggedUserDTO Login([FromBody] LoginDTO loginDTO)
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                return Ok(_autoryzacjaService.Login(loginDTO));
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
