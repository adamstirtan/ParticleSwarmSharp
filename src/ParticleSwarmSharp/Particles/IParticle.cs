namespace ParticleSwarmSharp.Particles
{
    /// <summary>
    /// Defines an interface for a particle
    /// </summary>
    public interface IParticle
    {
        /// <summary>
        /// Gets the fitness, if evaluated.
        /// </summary>
        double? Fitness { get; set; }

        /// <summary>
        /// Gets the number of dimensions.
        /// </summary>
        int Dimensions { get; set; }

        /// <summary>
        /// Creates a cloned instance.
        /// </summary>
        /// <returns></returns>
        IParticle Clone();
    }
}