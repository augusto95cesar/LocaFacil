using LocaFacilWeb.Models.Enums;
using LocaFacilWeb.Models.Repository;
using System; 
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LocaFacilWeb.Models.Helpers
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        LocaFacilContext context = new LocaFacilContext(); // my entity  
        private readonly TipoUsuarios[] allowedroles;

        //public CustomAuthorize(params string[] roles)
        //{
        //    this.allowedroles = roles;
        //}
        public CustomAuthorize(params TipoUsuarios[] tipoUsuarios)
        {
            this.allowedroles = tipoUsuarios;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                // Get the claims values
                try
                {
                    String userName = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                                                      .Select(c => c.Value).SingleOrDefault();
                    var loginUser = context.Usuarios.Where(x => x.Login == userName).SingleOrDefault();
                    //int roleId = context.Roles.SingleOrDefault(x => x.RoleName == role).RoleID;
                    //var user = context.Usuarios.Where(m => m.RoleID == roleId && m.Login == userName).ToList();
                    var user = context.Usuarios.Where(m => m.Login == userName).ToList();
                    if (user.Count() > 0)
                    {
                        authorize = true; /* return true if Entity has current user(active) with specific role */
                    }

                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }


    }
}