using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinarySearchController : ControllerBase
    {
        [HttpPost]
        public IActionResult BinarySearch([FromBody] BinarySearchModel model)
        {
            int left = 0;
            int right = model.Array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (model.Array[mid] == model.Target)
                {
                    return Ok(mid);
                }
                if (model.Array[mid] < model.Target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return NotFound(new { Message = "Target not found in the array." });
        }
    }
}
