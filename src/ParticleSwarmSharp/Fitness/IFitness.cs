﻿using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Fitness
{
    /// <summary>
    /// Defines an interface for particle swarm optimization fitness.
    /// </summary>
    public interface IFitness
    {
        /// <summary>
        /// Performs the fitness evaluation for the particle.
        /// </summary>
        /// <param name="particle">The particle to be evaluated.</param>
        double Evaluate(IParticle particle);
    }
}