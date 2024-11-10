using Microsoft.AspNetCore.Mvc;
using waterBuckets.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waterBuckets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
       
        // POST api/<SolutionController>
        [HttpPost]
        public IActionResult Post([FromBody] Requirements req)
        {

            var result = new { solution = new List<Step>()};

            if (req == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;


                return new JsonResult(result);
            }


            if (req.x_capacity < 0 || req.y_capacity < 0 || req.z_amount_wanted < 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;

                return new JsonResult(result);
            }

            Response.StatusCode = StatusCodes.Status200OK;

            int x = Math.Min(req.x_capacity, req.y_capacity);
            int y = Math.Max(req.x_capacity, req.y_capacity);

            result = new { solution = Solution.generate(x, y, req.z_amount_wanted) };

            return new JsonResult(result);
        }

      
    }
}
