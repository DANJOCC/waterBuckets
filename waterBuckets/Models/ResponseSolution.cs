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
        /// {
        /// "solution":[]
        /// }
        /// </example>
        public List<Step> solution { get; set; } = new List<Step>();
    }
}
