using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        public event EventHandler BestParticleChanged;

        public DateTime CreatedAt { get; protected set; }

        public Particle BestParticle { get; protected set; }

        public Population(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            CreatedAt = DateTime.Now;
        }

        public void CreateInitialGeneration()
        {
            throw new NotImplementedException();
        }

        public void EndGeneration()
        {
            throw new NotImplementedException();
        }
    }
}