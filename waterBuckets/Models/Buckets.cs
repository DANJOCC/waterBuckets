using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace waterBuckets.Models
{
    #pragma warning disable CS1591
    /// <summary>
    ///     Object with buckets capacities and water gallons wanted
    /// </summary>
    
    public class Buckets
    {
        /// <summary>
        /// Capacity of bucket X
        /// </summary>
        /// <example>6</example>
        
        public int x_capacity { get; set; }

        /// <summary>
        /// Capacity of bucket Y
        /// </summary>
        /// <example>25</example>
        
        public int y_capacity { get; set; }

        /// <summary>
        /// Amount of water gallons wanted
        /// </summary>
        /// <example>13</example>
        public int z_amount_wanted { get; set; }
    }
}
