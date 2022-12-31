using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Fitness
{
    /// <summary>
    /// Defines an interface for particle swarm optimization fitness.
    /// </summary>
    public interface IFitnessFunction
    {
        /// <summary>
        /// Performs the fitness evaluation for the specified <see cref="Particle"/>
        /// </summary>
        /// <param name="particle">The particle to be evaluated.</param>
        double Evaluate(Particle particle);
    }
}