using System.Security.Cryptography;
using System.Text;
using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RsaController : ControllerBase
    {
        [HttpPost("generateKeys")]
        public IActionResult GenerateKeys()
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);
            return Ok(new RsaModel { PublicKey = publicKey, PrivateKey = privateKey });
        }
        
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] RsaModel model, [FromQuery] string data)
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(model.PublicKey);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var encryptedBytes = rsa.Encrypt(dataBytes, false);
            return Ok(Convert.ToBase64String(encryptedBytes));
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] RsaModel model, [FromQuery] string encryptedData)
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(model.PrivateKey);
            var encryptedBytes = Convert.FromBase64String(encryptedData);
            var decryptedBytes = rsa.Decrypt(encryptedBytes, false);
            return Ok(Encoding.UTF8.GetString(decryptedBytes));
        }
    }
}
