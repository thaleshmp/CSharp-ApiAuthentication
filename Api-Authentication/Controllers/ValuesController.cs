using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Api_Authentication.Controllers
{
    public class ValuesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/values/index")]
        public IHttpActionResult Index()
        {
            return Ok("Usuário não autenticado, utilize o /token da API para obter acesso aos nossos dados");
        }

        [Authorize]
        [HttpGet]
        [Route("api/values/isauthorized")]
        public IHttpActionResult CheckAuthorized()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value);
            return Ok("Olá " + identity.Name + " Role: " + string.Join(",", roles));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/values/onlyadmin")]
        public IHttpActionResult OnlyAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value);
            return Ok("Olá " + identity.Name + " Role: " + string.Join(",", roles));
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("api/values/onlyuser")]
        public IHttpActionResult OnlyUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value);
            return Ok("Olá " + identity.Name + " Role: " + string.Join(",", roles));
        }
    }
}
