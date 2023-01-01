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
            var bestFitness = particleSwarm.BestParticle.Fitness.Value;

            if (_lastFitness == bestFitness)
            {
                _stagnatedGenerationCount++;
            }
            else
            {
                _stagnatedGenerationCount = 1;
            }

            _lastFitness = bestFitness;

            return _stagnatedGenerationCount >= _stagnatedGenerationLimit;
        }
    }
}