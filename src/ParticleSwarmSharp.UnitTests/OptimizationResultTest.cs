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
            IPopulation population = new Population(100);

            IParticleSwarm swarm = new ParticleSwarm(population, new FuncFitness((particle) =>
            {
                double x1 = particle.Position[0];
                double y1 = particle.Position[1];
                double x2 = particle.Position[2];
                double y2 = particle.Position[3];

                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }));

            OptimizationResult result = swarm.Start();

            Assert.IsNotNull(result);
        }
    }
}