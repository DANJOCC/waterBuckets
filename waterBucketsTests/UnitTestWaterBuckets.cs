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

            Assert.AreEqual("No Solution", solution.First().action);
        }

        [TestMethod]
        public void test_buckets_capacities_lower_than_gallons()
        {
            int x = 4; int y = 3; int z = 7;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            List<Step> solution2 = new Solution().generateSolution(x = 5, y = 3, z = 7);

            List<Step> solution3 = new Solution().generateSolution(x = 2, y = 4, z = 8);

            Assert.AreEqual("No Solution", solution1.First().action);
            Assert.AreEqual("No Solution", solution2.First().action);
            Assert.AreEqual("No Solution", solution3.First().action);
        }

        [TestMethod]
        public void test_buckets_capacities_higher_than_gallons()
        {
            int x = 5; int y = 7; int z = 2;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);


            List<Step> solution2 = new Solution().generateSolution(x = 24, y = 10, z = 7);

            List<Step> solution3 = new Solution().generateSolution(x = 100, y = 24, z = 2);

            Assert.AreEqual("Solution", solution1.First().action);
            Assert.AreEqual("No Solution", solution2.First().action);
            Assert.AreEqual("No Solution", solution3.First().action);
        }

        [TestMethod]
        public void gallons_between_buckets_capacities()
        {
            int x = 1; int y = 100; int z = 96;

            List<Step> solution1 = new Solution().generateSolution(x, y, z);

            Assert.AreEqual("Solution", solution1.First().action, true,
               $"values : x = {x} y = {y} z = {z}");

            List<Step> solution2 = new Solution().generateSolution(x = 2, y = 5, z = 3);

            Assert.AreEqual("Solution", solution2.First().action, true,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution3 = new Solution().generateSolution(x = 6, y = 25, z = 12);

            Assert.AreEqual("Solution", solution3.First().action, true,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution4 = new Solution().generateSolution(x = 6, y = 25, z = 13);

            Assert.AreEqual("Solution", solution4.First().action, true,
              $"values : x = {x} y = {y} z = {z}");

            List<Step> solution5 = new Solution().generateSolution(x = 6, y = 25, z = 15);

            Assert.AreEqual("No Solution", solution5.First().action, true,
              $"values : x = {x} y = {y} z = {z}");
        }


    }
}