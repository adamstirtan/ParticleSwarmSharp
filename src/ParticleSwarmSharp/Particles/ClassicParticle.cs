using ParticleSwarmSharp.Randomization;

namespace ParticleSwarmSharp.Particles
{
    /// <summary>
    /// Classical particle swarm optimization as proposed in https://ieeexplore.ieee.org/document/488968.
    /// </summary>
    public class ClassicParticle : Particle
    {
        protected static readonly double DefaultInertia = 0.9;
        protected static readonly double DefaultCognition = 1.4;
        protected static readonly double DefaultSocial = 1.4;

        protected double Inertia { get; set; }
        protected double Cognition { get; set; }
        protected double Social { get; set; }

        private double? _fitness;

        protected readonly IRandomization Random = new BasicRandomization();

        public ClassicParticle(int dimensions) : this(dimensions, DefaultInertia, DefaultCognition, DefaultSocial)
        { }

        public ClassicParticle(int dimensions, double inertia, double cognition, double social) : base(dimensions)
        {
            Inertia = inertia;
            Cognition = cognition;
            Social = social;

            PersonalBest = this;
        }

        public IParticle PersonalBest { get; private set; }

        public override double? Fitness
        {
            get { return _fitness; }
            set
            {
                if (PersonalBest.Fitness == null || value < PersonalBest.Fitness)
                {
                    PersonalBest = Clone();
                }

                _fitness = value;
            }
        }

        public override IParticle Clone()
        {
            IParticle clone = new ClassicParticle(Dimensions, Inertia, Cognition, Social);

            Position.CopyTo(clone.Position, 0);
            Velocity.CopyTo(clone.Velocity, 0);

            if (_fitness != null)
            {
                clone.Fitness = _fitness;
            }

            return clone;
        }

        public override void Update(params IParticle[] particles)
        {
            ClassicParticle globalBest = (ClassicParticle)particles.First();

            double r1 = Random.GetDouble();
            double r2 = Random.GetDouble();

            for (int d = 0; d < Dimensions; d++)
            {
                Velocity[d] =
                    Inertia * Velocity[d] +
                    Cognition * r1 * (PersonalBest.Position[d] - Position[d]) +
                    Social * r2 * (globalBest.Position[d] - Position[d]);

                Position[d] += Velocity[d];
            }
        }
    }
}