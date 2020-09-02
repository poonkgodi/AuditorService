using AuditorService.Models;
using AuditorService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Controllers
{
    public class UserAuthenticationController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepository<User> _repoUser;
        public int Id = 0;
        public UserAuthenticationController(IRepository<User> repoUser)
        {
            this._repoUser = repoUser;
        }
        //Get specific Values
        [HttpHead("Userlogin")]
        public IActionResult Userlogin(string userName, string password)
        {
            string pass = UtilityRepository.Encrypt(password, "sblw-3hn8-sqoy19");
            var userExisitngData = _repoUser.GetAllasync();
            var userData = userExisitngData.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (userData.Password != null)
            {
                string passDecypt = UtilityRepository.Decrypt(userData.Password, "sblw-3hn8-sqoy19");
                if (passDecypt == password)
                {
                    return Ok(userData);
                }
                else
                {
                    return Forbid();
                }
            }
            else
                return null;
        }
    }
}
