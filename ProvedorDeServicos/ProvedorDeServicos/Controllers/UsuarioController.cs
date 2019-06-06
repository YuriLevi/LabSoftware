using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProvedorDeServicos.Models;

namespace ProvedorDeServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _singInManager;

        public UsuarioController(UserManager<Usuario> userManager , SignInManager<Usuario> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }


        [HttpPost]
        [Route("Register")]
        //POST : api/Usuario/Register

        public async Task<object> PostAplicationUser(UsuarioModel model)
        {
            var usuario = new Usuario()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result =await _userManager.CreateAsync(usuario, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("Login")]
        //POST : api/Usuario/Login

        public async Task<ActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),

                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("zueirazueirazueira")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securitytoken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securitytoken);
                return Ok(new { token }); 
            }
            else
                return BadRequest(new {message = "Usuario ou login incorreto."}); 
        }

        private bool IsNullOrEmpty(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}