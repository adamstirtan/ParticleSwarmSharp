using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        public Population(IEnumerable<IParticle> particles)
        {
            if (!particles.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(particles));
            }

            CreatedAt = DateTime.Now;
            GenerationNumber = 1;

            Generation initial = new(GenerationNumber, particles);

            Generations = new List<Generation>
            {
                initial
            };

            CurrentGeneration = initial;
        }

        public DateTime CreatedAt { get; protected set; }

        public IParticle? BestParticle { get; set; }

        public IList<Generation> Generations { get; protected set; }

        public Generation? CurrentGeneration { get; protected set; }

        public int GenerationNumber { get; protected set; }

        /// <summary>
        /// Occurs when a new best particle is found.
        /// </summary>
        public event EventHandler? BestParticleChanged;

        protected virtual void OnBestParticleChanged(BestParticleChanged e)
        {
            BestParticleChanged?.Invoke(this, e);
        }

        public void CreateGeneration()
        {
            CurrentGeneration = new Generation(++GenerationNumber, CurrentGeneration.Particles);
            Generations.Add(CurrentGeneration);
        }

        public virtual void EndGeneration()
        {
            if (CurrentGeneration == null)
            {
                return;
            }

            CurrentGeneration.End();

            if (BestParticle != CurrentGeneration.BestParticle)
            {
                BestParticle = CurrentGeneration.BestParticle;

                OnBestParticleChanged(new BestParticleChanged(BestParticle));
            }
        }
    }
}