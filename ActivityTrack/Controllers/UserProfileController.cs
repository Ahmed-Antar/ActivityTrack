using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivityTrack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTrack.Controllers
{
    /// <summary>
    /// Profile Utilisateur
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Retoune le profile utilisateur
        /// </summary>
        /// <returns>objet utilisateur</returns>
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
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