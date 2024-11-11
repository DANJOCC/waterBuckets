using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using waterBuckets.Models;
using System.Net;
namespace waterBucketsIntegrationTest
{
    [TestClass]
    public class IntegrationTestWaterBuckets
    {

        
        [TestMethod]
        public async void getSolution()
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            HttpClient client = factory.CreateClient();
            Buckets buckets = new Buckets();

            buckets.x_capacity = 6;
            buckets.y_capacity = 25;
            buckets.z_amount_wanted = 13;

            JsonContent content = JsonContent.Create(
                  buckets
                );

            var response = await client.PostAsync("/api/Solution",content);

            Assert.IsTrue(response.IsSuccessStatusCode);


            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}