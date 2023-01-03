namespace ParticleSwarmSharp.Termination
{
    public class GenerationCountTermination : ITermination
    {
        private readonly int _maximumGenerations;

        public GenerationCountTermination(int maximumGenerations)
        {
            _maximumGenerations = maximumGenerations;
        }

        public bool HasReached(IParticleSwarm particleSwarm)
        {
            if (particleSwarm.IterationNumber > _maximumGenerations)
            {
                return true;
            }

            return false;
        }
    }
}