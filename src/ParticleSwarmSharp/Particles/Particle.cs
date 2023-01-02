namespace ParticleSwarmSharp.Particles
{
    public abstract class Particle : IParticle
    {
        protected double[] Position;
        protected double[] Velocity;

        public double? Fitness { get; set; }

        public int Dimensions { get; set; }

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