namespace waterBuckets.Models
{
    #pragma warning disable CS1591
    public class ResponseSolution
    {
        /// <summary>
        /// Response object to solution request
        /// </summary>
        ///<example>
        ///
        ///[
        ///    {
        ///         "step": 1,
        ///         "bucketX": 0,
        ///         "bucketY": 25,
        ///         "action": "Fill bucket Y",
        ///         "status": "Unsolved"
        ///    },
        ///    {
        ///    "step": 2,
        ///    "bucketX": 6,
        ///    "bucketY": 19,
        ///    "action": "Transfer from bucket Y to bucket X",
        ///    "status": "Unsolved"
        ///    },
        ///    {
        ///    "step": 3,
        ///    "bucketX": 0,
        ///    "bucketY": 19,
        ///    "action": "Empty bucket X",
        ///    "status": "Unsolved"
        ///    },
        ///    {
        ///     "step": 4,
        ///     "bucketX": 6,
        ///     "bucketY": 13,
        ///     "action": "Transfer from bucket Y to bucket X",
        ///     "status": "Solved"
        ///   }
        /// ]
        /// 
        /// </example>
        public List<Step> solution { get; set; } = new List<Step>();
    }
}
