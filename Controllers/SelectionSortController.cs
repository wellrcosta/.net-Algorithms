using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionSortController : ControllerBase
    {
        [HttpPost]
        public IActionResult SelectionSort([FromBody] SelectionSortModel model)
        {
            for (int i = 0; i < model.Array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < model.Array.Length; j++) {
                    if (model.Array[j] < model.Array[minIndex]) {
                        minIndex = j;
                    }
                }
                (model.Array[i], model.Array[minIndex]) = (model.Array[minIndex], model.Array[i]);
            }

            return Ok(model.Array);
        }
    }
}
