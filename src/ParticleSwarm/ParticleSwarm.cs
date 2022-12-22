namespace ParticleSwarm
{
    public class ParticleSwarm : IParticleSwarm
    {
        private readonly ParticleSwarmOptions _options;

        private List<Particle> _particles;

        public ParticleSwarm(ParticleSwarmOptions options)
        {
            _options = options;

            _particles = new List<Particle>(_options.PopulationSize);
        }

        public OptimizationResult Optimize()
        {
            OptimizationResult result = new();

            for (int iteration = 0; iteration < _options.Iterations; iteration++)
            {
                foreach (Particle particle in _particles)
                {
                    particle.Update();
                }
            }

            return result;
        }
    }
}
