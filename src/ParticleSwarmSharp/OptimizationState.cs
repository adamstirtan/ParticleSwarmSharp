namespace ParticleSwarmSharp
{
    /// <summary>
    /// The possible states for a particle swarm optimization.
    /// </summary>
    public enum OptimizationState
    {
        /// <summary>
        /// The optimization has not been started yet.
        /// </summary>
        NotStarted,

        /// <summary>
        /// The optimization has been started and is running.
        /// </summary>
        Started,

        /// <summary>
        /// The optimization has been stopped and is not running.
        /// </summary>
        Stopped,

        /// <summary>
        /// The optimization was stopped and is now running.
        /// </summary>
        Resumed,

        /// <summary>
        /// The optimization's termination criteria has been reached and is not running.
        /// </summary>
        TerminationReached
    }
}