using System.Linq;
using waterBuckets;
using waterBuckets.Models;

namespace waterBucketsTests
{
    [TestClass]
    public class UnitTestWaterBuckets
    {
        [TestMethod]
        public void test_two_even_buckets_and_odd_gallons()
        {
            int x = 2; int y = 10; int z = 7;

            List<Step> solution = new Solution().generateSolution(x,y,z);

            Assert.AreEqual(false, solution.Last().status);
        }

        [TestMethod]
        public void test_buckets_capacities_lower_than_gallons()
        {
            int x = 4; int y = 3; int z = 7;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            List<Step> solution2 = new Solution().generateSolution(x = 5, y = 3, z = 7);

            List<Step> solution3 = new Solution().generateSolution(x = 2, y = 4, z = 8);

            Assert.AreEqual(false, solution1.Last().status);
            Assert.AreEqual(false, solution2.Last().status);
            Assert.AreEqual(false, solution3.Last().status);
        }

        [TestMethod]
        public void test_buckets_capacities_higher_than_gallons()
        {
            int x = 5; int y = 7; int z = 2;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            Assert.AreEqual(true, solution1.Last().status, $"values : x = {x} y = {y} z = {z}");

            List<Step> solution2 = new Solution().generateSolution(x = 10, y = 24, z = 7);

            Assert.AreEqual(false, solution2.Last().status, $"values : x = {x} y = {y} z = {z}");

            List<Step> solution3 = new Solution().generateSolution(x = 24, y = 100, z = 2);

            
            Assert.AreEqual(false, solution3.Last().status, $"values : x = {x} y = {y} z = {z}");
        }

        [TestMethod]
        public void gallons_between_buckets_capacities()
        {
            int x = 1; int y = 100; int z = 96;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            Assert.AreEqual(true, solution1.Last().status,
               $"values : x = {x} y = {y} z = {z}");

            List<Step> solution2 = new Solution().generateSolution(x = 2, y = 5, z = 3);

            Assert.AreEqual(true, solution2.Last().status,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution3 = new Solution().generateSolution(x = 6, y = 25, z = 12);

            Assert.AreEqual(true, solution3.Last().status,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution4 = new Solution().generateSolution(x = 6, y = 25, z = 13);

            Assert.AreEqual(true, solution4.Last().status,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution5 = new Solution().generateSolution(x = 6, y = 25, z = 15);

            Assert.AreEqual(false, solution5.Last().status,
              $"values : x = {x} y = {y} z = {z}");
        }
        [TestMethod]
        public void found_best_solution()
        {
            int x = 2; int y = 10; int z = 4;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            Assert.AreEqual(4, solution1.Count,
               $"values : x = {x} y = {y} z = {z}");

            List<Step> solution2 = new Solution().generateSolution(x = 2, y = 100, z = 96);

            Assert.AreEqual(4, solution2.Count,
               $"values : x = {x} y = {y} z = {z}");

            List<Step> solution3 = new Solution().generateSolution(x = 4, y = 25, z = 12);

            Assert.AreEqual(6, solution3.Count,
               $"values : x = {x} y = {y} z = {z}");

            List<Step> solution4 = new Solution().generateSolution(x = 6, y = 25, z = 7);

            Assert.AreEqual(6, solution4.Count,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution5 = new Solution().generateSolution(x = 5, y = 7, z = 2);

            Assert.AreEqual(2, solution5.Count,
              $"values : x = {x} y = {y} z = {z}");
        }
    }
}