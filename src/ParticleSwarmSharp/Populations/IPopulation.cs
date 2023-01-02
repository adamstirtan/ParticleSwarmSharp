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
        /// Gets the set of generations.
        /// </summary>
        IList<Generation> Generations { get; }

        /// <summary>
        /// Gets the current generation of particles.
        /// </summary>
        Generation? CurrentGeneration { get; }

        /// <summary>
        /// Gets the current generation number.
        /// </summary>
        int GenerationNumber { get; }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the best particle.
        /// </summary>
        IParticle? BestParticle { get; set; }

        /// <summary>
        /// Advances to the next generation.
        /// </summary>
        void CreateGeneration();

        /// <summary>
        ///  Ends the current generation.
        /// </summary>
        void EndGeneration();
    }
}