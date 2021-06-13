using EMS.Model.Utility;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EMS.CustomFilters
{
    public class JWTAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var jwtToken = authzHeaders.ElementAt(0);
            token = jwtToken.StartsWith("JWT ") ? jwtToken.Substring(4) : jwtToken;
            // token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {

            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(actionContext.Request, out token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
            }
            else
            {
                SecurityToken securityToken;
                try
                {

                    var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(Helper.SymmetricSecurityKey));

                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                    TokenValidationParameters validationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateIssuer=false,
                       // ValidIssuer = "https://localhost:44329/",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        LifetimeValidator = this.LifetimeValidator,
                        IssuerSigningKey = securityKey
                    };
                    //extract and assign the user of the jwt
                    Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                    HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);
                }
                catch (SecurityTokenValidationException e)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                catch (Exception ex)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }


        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}