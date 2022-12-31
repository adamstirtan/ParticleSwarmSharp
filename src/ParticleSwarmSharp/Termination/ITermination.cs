namespace ParticleSwarmSharp.Termination
{
    /// <summary>
    /// Defines an interface for a termination criteria.
    /// </summary>
    public interface ITermination
    {
        /// <summary>
        /// Determines whether the particle swarm has reached the termination criteria.
        /// </summary>
        /// <param name="particleSwarm">The particle swarm</param>
        bool HasReached(IParticleSwarm particleSwarm);
    }
}