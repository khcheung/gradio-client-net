using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
            var result = await client.PredictAsync(0, "Test");
            Console.WriteLine(result);
            Assert.AreEqual("Hello Test!!", result[0]);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
            var result = await client.PredictAsync(1, "Test");
            Console.WriteLine(result);
            Assert.AreEqual("Hello Test!!", result[0]);
        }

        [TestMethod]
        public async Task TestMethod3()
        {
            var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
            var result = await client.PredictAsync(2, "Test");
            Console.WriteLine(result);
            Assert.AreEqual("Hello Test!!", result[0]);
        }

        [TestMethod]
        public async Task TestNamedAPI()
        {
            var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
            var result = await client.PredictAsync("/namedyield", "Test");
            Console.WriteLine(result);
            Assert.AreEqual("Hello Test!!", result[0]);
        }
    }
}