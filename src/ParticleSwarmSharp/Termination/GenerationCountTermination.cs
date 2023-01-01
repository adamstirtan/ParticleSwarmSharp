namespace ParticleSwarmSharp.Termination
{
    public class GenerationCountTermination : ITermination
    {
        private int _maximumGenerations;
        private int _generationNumber;

        public GenerationCountTermination(int maximumGenerations)
        {
            _maximumGenerations = maximumGenerations;
        }

        public bool HasReached(IParticleSwarm particleSwarm)
        {
            if (++_generationNumber > _maximumGenerations)
            {
                return true;
            }

            return false;
        }
    }
}