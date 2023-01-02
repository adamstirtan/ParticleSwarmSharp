using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;

using Moq;

namespace ParticleSwarmSharp.UnitTests.Fitness
{
    [TestClass]
    public class FuncFitnessTests
    {
        [TestMethod]
        public void ConstantValueTest()
        {
            const double value = 100.0;

            Mock<ClassicParticle> mockParticle = new(MockBehavior.Strict, new object[] { 3 });

            FuncFitness fitness = new(particle =>
            {
                return value;
            });

            Assert.AreEqual(value, fitness.Evaluate(mockParticle.Object));
        }
    }
}