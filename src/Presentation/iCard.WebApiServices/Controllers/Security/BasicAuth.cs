using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNetCore.Http;

namespace iCard.WebApiServices.Controllers.Security
{
    public class BasicAuth : AuthorizationFilterAttribute
    {
        private IHttpContextAccessor _httpContextAccessor;
        private UserLogin userLogin = new UserLogin();
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.RequestUri.AbsoluteUri.Contains("api/user/register"))
            {
                return;
            }
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers
                    .Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                if (userLogin.Login(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                    if ( _httpContextAccessor.HttpContext.User != null)
                    {
                        _httpContextAccessor.HttpContext.User = (ClaimsPrincipal) principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }

}