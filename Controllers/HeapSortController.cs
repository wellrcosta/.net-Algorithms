using Algorithms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeapSortController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sort([FromBody] HeapSortModel model)
        {
            int n = model.Array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(model.Array, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                (model.Array[0], model.Array[i]) = (model.Array[i], model.Array[0]);
                Heapify(model.Array, i, 0);
            }
            return Ok(model.Array);
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;
            if (largest != i)
            {
                (array[i], array[largest]) = (array[largest], array[i]);
                Heapify(array, n, largest);
            }
        }

    }
}
