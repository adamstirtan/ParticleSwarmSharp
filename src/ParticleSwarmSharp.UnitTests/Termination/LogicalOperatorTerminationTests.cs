using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Termination;

using Moq;

namespace ParticleSwarmSharp.UnitTests.Termination
{
    [TestClass]
    public class LogicalOperatorTerminationTests
    {
        [TestMethod]
        public void OrTerminationTest()
        {
            const int generations = 10;

            Mock<IParticleSwarm> mockSwarm = new();
            Mock<ClassicParticle> mockParticle = new(
                MockBehavior.Strict, new object[] { 10 });

            mockSwarm.Setup(x => x.BestParticle).Returns(mockParticle.Object);

            OrTermination sut = new(
                new GenerationCountTermination(10),
                new FitnessThresholdTermination(1.0));

            for (int i = 0; i < generations; i++)
            {
                Assert.IsFalse(sut.HasReached(mockSwarm.Object));
            }

            Assert.IsTrue(sut.HasReached(mockSwarm.Object));
        }

        [TestMethod]
        public void AndTerminationTest()
        {
            const int generations = 10;

            Mock<IParticleSwarm> mockSwarm = new();
            Mock<ClassicParticle> mockParticle = new(
                MockBehavior.Strict, new object[] { 10 });

            mockSwarm.Setup(x => x.BestParticle).Returns(mockParticle.Object);
            mockSwarm.Setup(x => x.RunTime).Returns(TimeSpan.FromSeconds(2));

            AndTermination sut = new(
                new GenerationCountTermination(10),
                new TimeSpanTermination(TimeSpan.FromSeconds(1)));

            for (int i = 0; i < generations; i++)
            {
                Assert.IsFalse(sut.HasReached(mockSwarm.Object));
            }

            Assert.IsTrue(sut.HasReached(mockSwarm.Object));
        }
    }
}