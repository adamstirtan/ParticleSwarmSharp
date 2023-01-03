namespace ParticleSwarmSharp.Termination
{
    public class FitnessStagnationTermination : ITermination
    {
        private readonly int _stagnatedGenerationLimit;

        private int _stagnatedGenerationCount;
        private double _lastFitness;

        public FitnessStagnationTermination()
            : this(100)
        { }

        public FitnessStagnationTermination(int stagnatedGenerationLimit)
        {
            _stagnatedGenerationLimit = stagnatedGenerationLimit;
        }

        public bool HasReached(IParticleSwarm particleSwarm)
        {
            if (particleSwarm.BestParticle == null || particleSwarm.BestParticle.Fitness == null)
            {
                return false;
            }

            var bestFitness = particleSwarm.BestParticle.Fitness;

            if (_lastFitness == bestFitness)
            {
                _stagnatedGenerationCount++;
            }
            else
            {
                _stagnatedGenerationCount = 1;
            }

            _lastFitness = bestFitness.Value;

            return _stagnatedGenerationCount >= _stagnatedGenerationLimit;
        }
    }
}