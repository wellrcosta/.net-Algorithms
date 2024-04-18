using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BubbleSortController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sort([FromBody] BubbleSortModel model)
        {
            int n = model.Array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (model.Array[j] > model.Array[j + 1])
                    {
                        // Swap model.Array[j] and model.Array[j + 1]
                        (model.Array[j], model.Array[j + 1]) = (model.Array[j + 1], model.Array[j]);
                    }
                }
            }
            return Ok(model.Array);
        }
        
    }
}
