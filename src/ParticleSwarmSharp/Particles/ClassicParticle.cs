namespace ParticleSwarmSharp.Particles
{
    /// <summary>
    /// Classical particle swarm optimization as proposed in https://ieeexplore.ieee.org/document/488968.
    /// </summary>
    public class ClassicParticle : Particle
    {
        private static readonly double DefaultInertia = 0.9;
        private static readonly double DefaultCognition = 1.4;
        private static readonly double DefaultSocial = 1.4;

        private readonly Random _random = new();

        private double _inertia;
        private double _cognition;
        private double _social;
        private double? _fitness;

        public ClassicParticle(int dimensions) : this(dimensions, DefaultInertia, DefaultCognition, DefaultSocial)
        { }

        public ClassicParticle(int dimensions, double inertia, double cognition, double social) : base(dimensions)
        {
            _inertia = inertia;
            _cognition = cognition;
            _social = social;

            Position = new double[dimensions];

            for (int d = 0; d < dimensions; d++)
            {
                Position[d] = _random.NextDouble();
                Velocity[d] = _random.NextDouble();
            }
        }

        public IParticle PersonalBest { get; private set; }

        public override double? Fitness
        {
            get { return _fitness; }
            set
            {
                if (PersonalBest == null || value < PersonalBest.Fitness)
                {
                    PersonalBest = Clone();
                }

                _fitness = value;
            }
        }

        public override IParticle Clone()
        {
            ClassicParticle clone = new(Dimensions, _inertia, _cognition, _social);

            Position.CopyTo(clone.Position, 0);
            Velocity.CopyTo(clone.Velocity, 0);

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
                    _inertia * Velocity[d] +
                    _cognition * r1 * (PersonalBest.Position[d] - Position[d]) +
                    _social * r2 * (globalBest.Position[d] - Position[d]);

                Position[d] += Velocity[d];
            }
        }
    }
}