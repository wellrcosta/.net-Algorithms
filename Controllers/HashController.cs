using System.Security.Cryptography;
using System.Text;
using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        [HttpPost("sha256")]
        public IActionResult Sha256([FromBody] HashModel model)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(model.Data);
            var hashBytes = sha256.ComputeHash(bytes);
            model.Hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return Ok(model);
        }
    }
}
