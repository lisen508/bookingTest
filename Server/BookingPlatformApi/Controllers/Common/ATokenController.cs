using BookingPlatform.Common;
using BookingPlatform.Extensions;
using BookingPlatformApi.Controllers.Filter;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BookingPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATokenController : Controller
    {
        #region Token
        /// <summary>
        /// 模拟登录，获取JWT
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        [HttpGet("Admin"), Log("ATokenController：GetJWTAdmin", LogType = LogEnum.LOGIN)]
        public IActionResult GetJWTAdmin()
        {
            var tm = new TokenModel()
            {
                Uid = Guid.NewGuid().ToString(),
                UserName = "User",
                Role = "Admin",
                TokenType = "Web"
            };
            return Ok(JwtHelper.IssueJWT(tm));
        }
        #endregion

        #region Token
        /// <summary>
        /// 模拟登录，获取JWT
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        [HttpGet("App")]
        public IActionResult GetJWTApp()
        {
            var tm = new TokenModel()
            {
                Uid = Guid.NewGuid().ToString(),
                UserName = "User",
                Role = "App",
                TokenType = "App"
            };
            return Ok(JwtHelper.IssueJWT(tm));
        }
        #endregion
    }
}