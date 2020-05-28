using BookingPlatform.Extensions;
using BookingPlatformApi.Controllers.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatformApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AJwtController : ControllerBase
    {
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        [JwtAuthorize]
        [HttpGet, ApiAuthorize(Modules = "测试", Methods = "Admin")]
        public IActionResult Admin()
        {
            return Ok(new { title = "Admin张三" });
        }


        [HttpGet("app")]
        public IActionResult App()
        {
            return Ok(new { title = "APP李四" });
        }

        [JwtAuthorize(Roles = "Admin,App")]
        [HttpGet("all")]
        public IActionResult AdminApp()
        {
            return Ok(new { title = "Admin张三-----APP李四" });
        }
    }
}