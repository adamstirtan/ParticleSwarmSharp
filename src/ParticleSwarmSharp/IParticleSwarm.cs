namespace ParticleSwarmSharp
{
    /// <summary>
    /// Defines an interface for a Particle Swarm Optimization algorithm
    /// </summary>
    public interface IParticleSwarm
    {
        /// <summary>
        /// Occurs after an iteration completes.
        /// </summary>
        event EventHandler IterationComplete;

        /// <summary>
        /// Occurs when the termination criteria is reached.
        /// </summary>
        event EventHandler TerminationCriteriaReached;

        /// <summary>
        /// Occurs when optimization is stopped during runtime.
        /// </summary>
        event EventHandler Stopped;
        
        /// <summary>
        /// Gets the runtime for the optimization.
        /// </summary>
        TimeSpan RunTime { get; }

        /// <summary>
        /// Starts the optimization using the provided options.
        /// </summary>
        /// <returns></returns>
        OptimizationResult Start();

        /// <summary>
        /// Stops the running optimization.
        /// </summary>
        void Stop();
    }
}