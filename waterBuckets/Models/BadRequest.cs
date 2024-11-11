namespace waterBuckets.Models
{
#pragma warning disable CS1591

    /// <summary>
    ///     Object for BadRequest to endpoint /api/Solution
    /// </summary>
    public class BadRequest
    {
        /// <summary>
        /// message of bad request done
        ///</summary>
        ///<example>Negative values in one of body values</example>
        public string message { get; set; } ="";

        /// <summary>
        /// list empty for bad request
        ///</summary>
        ///<example>[]</example>
        public List<Step> solution { get; set; } = new List<Step>();

        public BadRequest(string message, List<Step> solution) { 
            this.message = message;
            this.solution = solution;
        }
       
    }
}
