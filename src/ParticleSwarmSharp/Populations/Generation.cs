﻿namespace ParticleSwarmSharp.Populations
{
    public class Generation
    {
        public Generation(int number, IEnumerable<Particle> particles)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (particles == null || !particles.Any())
            {
                throw new ArgumentNullException(nameof(particles));
            }

            Number = number;
            CreatedAt = DateTime.Now;
            Particles = particles;
        }

        public int Number { get; private set; }

        public DateTime CreatedAt { get; internal set; }

        public IEnumerable<Particle> Particles { get; internal set; }

        public Particle? BestParticle { get; internal set; }
    }
}