using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        public event EventHandler BestParticleChanged;

        public DateTime CreatedAt { get; protected set; }

        public IParticle BestParticle { get; set; }

        public IList<Generation> Generations { get; protected set; }

        public Generation CurrentGeneration { get; protected set; }

        public int GenerationNumber { get; protected set; }

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

        public virtual void CreateGeneration(IEnumerable<IParticle> particles)
        {
            CurrentGeneration = new Generation(++GenerationNumber, particles);
            Generations.Add(CurrentGeneration);
        }

        public virtual void EndGeneration()
        {
            CurrentGeneration.End();

            if (BestParticle != CurrentGeneration.BestParticle)
            {
                BestParticle = CurrentGeneration.BestParticle;

                OnBestParticleChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnBestParticleChanged(EventArgs e)
        {
            BestParticleChanged?.Invoke(this, e);
        }
    }
}