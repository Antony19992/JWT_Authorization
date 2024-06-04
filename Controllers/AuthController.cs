using jwt_authorization.Models;
using jwt_authorization.Security;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly JWTHelper _jwtHelper;
        public AuthController(JWTHelper jwtHelper)
            => _jwtHelper = jwtHelper;

        [HttpGet]
        public IActionResult Get()
        {
            //Em um projeto real os dados do usuários deveriam ser recebidos na requisição e validados.
            var user = new User
            {
                Guid = Guid.NewGuid().ToString(),
                Password = "123",
                Role = "Admin",
                Username = "antonycosta"
            };

            return Ok(new
            {
                Token = _jwtHelper.GenerateToken(user),
                User = user
            });
        }
    }
}