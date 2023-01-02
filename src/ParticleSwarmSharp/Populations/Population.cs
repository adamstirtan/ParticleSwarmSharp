using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        public Population(int populationSize)
        {
            if (populationSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(populationSize));
            }

            CreatedAt = DateTime.Now;
            GenerationNumber = 0;
            Generations = new List<Generation>();
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

        public void InitializeParticles(IEnumerable<IParticle> particles)
        {
            GenerationNumber = 1;

            Generation initial = new(GenerationNumber, particles);

            Generations.Clear();
            Generations.Add(initial);

            CurrentGeneration = initial;
        }

        public void CreateGeneration()
        {
            throw new NotImplementedException();
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