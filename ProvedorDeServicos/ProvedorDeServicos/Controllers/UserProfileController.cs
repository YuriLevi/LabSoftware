using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProvedorDeServicos.Models;

namespace ProvedorDeServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private UserManager<Usuario> _userManager;

        public UserProfileController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        //Get: api/UserProfile
        public async Task<object> GetUserprofile()
        {
            string userId = User.Claims.First(x => x.Type == "UserId").Value;

            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };

        }

    }
}