namespace ParticleSwarmSharp.Particles
{
    /// <summary>
    /// Defines an interface for a particle
    /// </summary>
    public interface IParticle
    {
        /// <summary>
        /// Gets the position.
        /// </summary>
        double[] Position { get; set; }

        /// <summary>
        /// Gets the velocity.
        /// </summary>
        double[] Velocity { get; set; }

        /// <summary>
        /// Gets the fitness, if evaluated.
        /// </summary>
        double? Fitness { get; set; }

        /// <summary>
        /// Gets the number of dimensions.
        /// </summary>
        int Dimensions { get; set; }

        /// <summary>
        /// Calculates the velocity and updates the position.
        /// </summary>
        /// <param name="particles"></param>
        void Update(params IParticle[] particles);

        /// <summary>
        /// Creates a cloned instance.
        /// </summary>
        /// <returns></returns>
        IParticle Clone();
    }
}