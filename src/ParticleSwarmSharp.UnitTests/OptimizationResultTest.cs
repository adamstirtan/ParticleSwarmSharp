using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Populations;

namespace ParticleSwarmSharp.UnitTests
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

            IPopulation population = new Population(options.PopulationSize);

            ParticleSwarm pso = new(options, population, new FuncFitness((particle) =>
            {
                double x1 = particle.Position[0];
                double y1 = particle.Position[1];
                double x2 = particle.Position[2];
                double y2 = particle.Position[3];

                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }));

            OptimizationResult result = pso.Start();

            Assert.IsNotNull(result);
        }
    }
}