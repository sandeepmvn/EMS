using EMS.BO;
using EMS.Model.PartialClass;
using EMS.Model.Utility;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace EMS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        UserProfileBO userProfileBO = new UserProfileBO();

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(UserModel userDetail)
        {
            if (ModelState.IsValid)
            {
                userDetail = userProfileBO.Authenticate(userDetail);
                if (userDetail.IsValid)
                {
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Helper.SymmetricSecurityKey));
                    SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


                    List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userDetail.UserProfile.FirstName+userDetail.UserProfile.LastName),
                    new Claim("UId",userDetail.UserProfile.EmployeeId.ToString()),
                    new Claim(ClaimTypes.Email,userDetail.UserProfile.EmailId),
                    new Claim(ClaimTypes.Role,userDetail.RoleName),
                };
                    DateTime tokenExpires_in = DateTime.UtcNow.AddDays(10);
                    JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: tokenExpires_in,
                        signingCredentials: signinCredentials
                    );
                    string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString, Expires_in = tokenExpires_in });

                }
                else
                    return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Ok();
        }
    }
}
