using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        private readonly int _size;

        public event EventHandler BestParticleChanged;

        public DateTime CreatedAt { get; protected set; }

        public IParticle BestParticle { get; protected set; }

        public IList<Generation> Generations { get; protected set; }

        public Generation CurrentGeneration { get; protected set; }

        public int GenerationNumber { get; protected set; }

        public Population(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            _size = size;

            CreatedAt = DateTime.Now;
        }

        public virtual void CreateInitialGeneration()
        {
            Generations = new List<Generation>();
            GenerationNumber = 0;

            var particles = new List<IParticle>();

            for (int i = 0; i < _size; i++)
            {
                IParticle p = new ClassicParticle(10);

                particles.Add(p);
            }

            CreateGeneration(particles);
        }

        public virtual void CreateGeneration(IEnumerable<IParticle> particles)
        {
            CurrentGeneration = new Generation(++GenerationNumber, particles);
            Generations.Add(CurrentGeneration);
        }

        public virtual void EndGeneration()
        {
        }

        protected virtual void OnBestParticleChanged(EventArgs e)
        {
            BestParticleChanged?.Invoke(this, e);
        }
    }
}