using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickSortController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sort([FromBody] QuickSortModel model)
        {
            QuickSort(model.Array, 0, model.Array.Length - 1);
            return Ok(model.Array);
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }
    }
}
