﻿using Microsoft.AspNetCore.Mvc;
using System;
using waterBuckets.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waterBuckets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
#pragma warning disable CS1591
    public class SolutionController : ControllerBase
    {
        /// <summary>
        /// Request solution from buckets and gallons values.
        /// </summary>
        /// <param name="buckets"></param>
        /// <returns> A Json with a key "solution" bounded with a list of step to get the solution  </returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /solution
        /// 
        ///     {
        ///         "x_capacity": 6,
        ///         "y_capacity": 25,
        ///         "z_amount_wanted": 13
        ///     }
        ///  
        /// </remarks>
        ///<response code="201"> Json Response with key "solution" an value equal to List with steps to get solution</response>
        /// <response code="400">Json Response with key "solution" an value equal to empty List of step</response>
        // POST api/<SolutionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseSolution))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        public JsonResult Post([FromBody] Buckets buckets)
        {

            ResponseSolution result = new ResponseSolution();

            if (buckets.x_capacity < 0 || buckets.y_capacity < 0 || buckets.z_amount_wanted < 0)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;


                BadRequest bad = new BadRequest("negative value in one of body values", []);

                return new JsonResult(bad);
            }

            Response.StatusCode = StatusCodes.Status201Created;

            int x = Math.Min(buckets.x_capacity, buckets.y_capacity);
            int y = Math.Max(buckets.x_capacity, buckets.y_capacity);

            result.solution = Solution.generate(x, y, buckets.z_amount_wanted);
            if (result.solution.Count == 0)
            {

                BadRequest bad = new BadRequest("No solution", []);

                return new JsonResult(bad);
            }
            return new JsonResult(result);
        }
    #pragma warning restore CS1591

    }
}
