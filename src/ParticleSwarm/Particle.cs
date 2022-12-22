namespace ParticleSwarm
{
    public class Particle
    {
        public double[] Position { get; set; }

        private readonly Random _rng = new();

        public Particle(int dimensions)
        {
            Position = new double[dimensions];
        }
        
        public virtual void Update()
        {
            for (var i = 0; i < Position.Length; i++)
            {
                Position[i] = _rng.NextDouble();
            }
        }

        public double Fitness()
        {
            return double.MaxValue;
        }
    }
}
