using BLL.Models;

namespace BLL
{
    public interface IAutoryzacjaService
    {
        public LoggedUserDTO Login(LoginDTO loginDTO);
    }
}
