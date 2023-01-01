namespace ParticleSwarmSharp.Termination
{
    public class FitnessThresholdTermination : ITermination
    {
        public double FitnessThreshold { get; set; }

        public FitnessThresholdTermination(double fitnessThreshold)
        {
            FitnessThreshold = fitnessThreshold;
        }

        public bool HasReached(IParticleSwarm particleSwarm)
        {
            return particleSwarm.BestParticle.Fitness >= FitnessThreshold;
        }
    }
}