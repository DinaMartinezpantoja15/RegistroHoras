/* using System.Web.Mvc;
using System.Web;
using RegistroHoras.Data;

public class CustomAuthorizationAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        // Implementa la lógica de autorización aquí
        return httpContext.Empleado.Identity.IsAuthenticated;
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        // Maneja la redirección en caso de acceso no autorizado
        if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                    { "controller", "Auth" },
                    { "action", "Login" }
                });
        }
        else
        {
            filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
        }
    }
        }
 */

