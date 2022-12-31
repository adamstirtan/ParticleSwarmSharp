using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    /// <summary>
    /// Defines an interface for a population of canadidate solutions.
    /// </summary>
    public interface IPopulation
    {
        /// <summary>
        /// Occurs when the best particle changes.
        /// </summary>
        event EventHandler BestParticleChanged;

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the best particle.
        /// </summary>
        Particle BestParticle { get; }

        /// <summary>
        /// Creates the initial generation of particles.
        /// </summary>
        void CreateInitialGeneration();

        /// <summary>
        /// Ends the current generation.
        /// </summary>
        void EndGeneration();
    }
}