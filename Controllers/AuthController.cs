using Lab2.Models;
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

namespace Lab2.Controllers
{
    public class AuthController : ApiController
    {
        Model1 db = new Model1();
        public IHttpActionResult postLogin(StudentCredentials auth)
        {
            if (auth == null)
                return BadRequest();
            if (auth.username == null || auth.password == null)
                return BadRequest();

            Student st = db.Students.Where(a => a.Username == auth.username && a.Password == auth.password).FirstOrDefault();
            if (st != null)
            {
                string secret = "MaJesTyXMaJesTyX";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                List<Claim> data = new List<Claim>();
                data.Add(new Claim("id", st.St_Id.ToString()));
                data.Add(new Claim("name", st.St_Fname + "_" + st.St_Lname));

                var token = new JwtSecurityToken(
                    claims: data,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Authorization = jwt_token });
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }
    }
}
