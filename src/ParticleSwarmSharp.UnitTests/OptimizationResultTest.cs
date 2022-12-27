namespace ParticleSwarm.UnityTests
{
    [TestClass]
    public class OptimizationResultTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ParticleSwarmOptions options = new()
            {
                PopulationSize = 100,
                Iterations = 25,
                Topology = Topologies.Star
            };

            ParticleSwarm pso = new(options);

            OptimizationResult result = pso.Optimize();

            Assert.IsNotNull(result);
        }
    }
}