using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    /// <summary>
    /// Represents a population of candidate solutions (particles).
    /// </summary>
    public class Population : IPopulation
    {
        private IParticle? _bestParticle;

        public Population(IList<IParticle> particles)
        {
            if (!particles.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(particles));
            }

            CreatedAt = DateTime.Now;
            Particles = particles;
        }

        public DateTime CreatedAt { get; protected set; }

        public IParticle? BestParticle
        {
            get
            {
                return _bestParticle;
            }
            set
            {
                _bestParticle = value;

                OnBestParticleChanged(new BestParticleChangedEventArgs(_bestParticle));
            }
        }

        public IList<IParticle> Particles { get; set; }

        /// <summary>
        /// Occurs when a new best particle is found.
        /// </summary>
        public event EventHandler? BestParticleChanged;

        protected virtual void OnBestParticleChanged(BestParticleChangedEventArgs e)
        {
            BestParticleChanged?.Invoke(this, e);
        }
    }
}