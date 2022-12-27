using ParticleSwarmSharp.Fitness;

namespace ParticleSwarmSharp
{
    public class Particle
    {
        private readonly double _inertia;
        private readonly double _cognitive;
        private readonly double _social;

        public double[] Position { get; set; }
        public double[] Velocity { get; set; }

        public double[] PersonalBest { get; set; }

        public Particle(double inertia, double cognitive, double social, int dimensions)
        {
            Position = new double[dimensions];
            Velocity = new double[dimensions];

            _inertia = inertia;
            _cognitive = cognitive;
            _social = social;
        }

        public virtual void Update(Particle globalBest)
        {
            Random random = new();

            for (int i = 0; i < Position.Length; i++)
            {
                double delta =
                    (_inertia * Velocity[i]) +
                    (_cognitive * random.NextDouble() * (PersonalBest[i] - Position[i])) +
                    (_social * random.NextDouble() * (globalBest.Position[i] - Position[i]));

                Position[i] += delta;
            }
        }

        public double GetFitness(IFitnessFunction fitnessFunction)
        {
            return double.MaxValue;
        }
    }
}