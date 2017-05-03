using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Api_Authentication.Providers
{
    public class APIContext
    {

        public static long UsuarioId
        {
            get
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                return long.Parse(identity.Claims.Where(x => x.Type == _USERKEY).FirstOrDefault().Value);
            }
        }


        public static string _USERKEY = "USUARIOID";
    }
}
