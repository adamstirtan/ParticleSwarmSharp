using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp
{
    /// <summary>
    /// Defines an interface for a Particle Swarm Optimization algorithm
    /// </summary>
    public interface IParticleSwarm
    {
        /// <summary>
        /// Occurs after an generation completes.
        /// </summary>
        event EventHandler GenerationComplete;

        /// <summary>
        /// Occurs when the termination criteria is reached.
        /// </summary>
        event EventHandler TerminationCriteriaReached;

        /// <summary>
        /// Occurs when optimization is stopped during runtime.
        /// </summary>
        event EventHandler Stopped;

        /// <summary>
        /// Gets the best particle.
        /// </summary>
        Particle BestParticle { get; }

        /// <summary>
        /// Gets the runtime for the optimization.
        /// </summary>
        TimeSpan RunTime { get; }

        /// <summary>
        /// Starts the optimization.
        /// </summary>
        /// <returns></returns>
        void Start();

        /// <summary>
        /// Stops the running optimization.
        /// </summary>
        void Stop();
    }
}