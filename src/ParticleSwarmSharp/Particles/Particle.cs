namespace ParticleSwarmSharp.Particles
{
    public abstract class Particle : IParticle
    {
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }

        public int Dimensions { get; set; }

        public virtual double? Fitness { get; set; }

        protected Particle(int dimensions)
        {
            Dimensions = dimensions;

            Position = new double[dimensions];
            Velocity = new double[dimensions];
        }

        public abstract void Update(params IParticle[] particles);

        public abstract IParticle Clone();
    }
}