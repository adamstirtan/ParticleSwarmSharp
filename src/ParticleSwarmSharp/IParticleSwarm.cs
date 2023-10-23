using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

namespace ParticleSwarmSharp
{
    /// <summary>
    /// Defines an interface for a Particle Swarm Optimization algorithm
    /// </summary>
    public interface IParticleSwarm
    {
        /// <summary>
        /// Occurs when a new best particle is found.
        /// </summary>
        event EventHandler BestParticleChanged;

        /// <summary>
        /// Occurs after an generation completes.
        /// </summary>
        event EventHandler GenerationComplete;

        /// <summary>
        /// Occurs when the termination criteria is reached.
        /// </summary>
        event EventHandler TerminationReached;

        /// <summary>
        /// Occurs when optimization is stopped during runtime.
        /// </summary>
        event EventHandler Stopped;

        /// <summary>
        /// Gets the optimization iteration number.
        /// </summary>
        int IterationNumber { get; set; }

        /// <summary>
        /// Gets the population.
        /// </summary>
        IPopulation Population { get; set; }

        /// <summary>
        /// Gets or sets the fitness function.
        /// </summary>
        IFitness Fitness { get; set; }

        /// <summary>
        /// Gets or sets the termination criteria.
        /// </summary>
        ITermination Termination { get; set; }

        /// <summary>
        /// Gets the current generation's best particle.
        /// </summary>
        IParticle BestParticle { get; }

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