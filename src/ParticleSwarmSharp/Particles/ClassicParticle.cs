namespace ParticleSwarmSharp.Particles
{
    public class ClassicParticle : Particle
    {
        private static readonly double DefaultInertia = 0.9;
        private static readonly double DefaultCognition = 1.4;
        private static readonly double DefaultSocial = 1.4;

        private readonly Random _random = new();

        public double Inertia;
        public double Cognition;
        public double Social;
        public double[] PersonalBest;

        public ClassicParticle(int dimensions) : this(dimensions, DefaultInertia, DefaultCognition, DefaultSocial)
        { }

        public ClassicParticle(int dimensions, double inertia, double cognition, double social) : base(dimensions)
        {
            Inertia = inertia;
            Cognition = cognition;
            Social = social;

            PersonalBest = new double[dimensions];
        }

        public override IParticle Clone()
        {
            ClassicParticle clone = new(Dimensions, Inertia, Cognition, Social);

            Position.CopyTo(clone.Position, 0);
            Velocity.CopyTo(clone.Velocity, 0);
            PersonalBest.CopyTo(clone.PersonalBest, 0);

            return clone;
        }

        public override void Update(params IParticle[] particles)
        {
            ClassicParticle globalBest = (ClassicParticle)particles.First();

            double r1 = _random.NextDouble();
            double r2 = _random.NextDouble();

            for (int d = 0; d < Dimensions; d++)
            {
                Velocity[d] =
                    Inertia * Velocity[d] +
                    Cognition * r1 * (PersonalBest[d] - Position[d]) +
                    Social * r2 * (globalBest.Position[d] - Position[d]);

                Position[d] += Velocity[d];
            }
        }
    }
}