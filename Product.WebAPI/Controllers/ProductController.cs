using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Product.WebAPI.Controllers
{
    [Route("api/x/[controller]")]
    [ApiController]   
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet("GetAuthorizedProducts")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get()
        {
            var user = User.Identity.IsAuthenticated;

            var claims = User.Claims.ToList();

            return "Authorized Products";
        }

        [HttpGet("GetPublicProducts")]
        public string GetPublic()
        {
            var user = User.Identity.IsAuthenticated;

            return "Public Products";
        }
    }
}