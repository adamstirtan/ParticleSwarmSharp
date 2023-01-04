using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Runner.ImageCopy
{
    public class ImageCopyParticle : ClassicParticle
    {
        private readonly int _width;

        public ImageCopyParticle(int dimensions, int width)
            : base(dimensions, DefaultInertia, DefaultCognition, DefaultSocial)
        {
            _width = width;

            InitializeParticle();
        }

        private void InitializeParticle()
        {
            for (int d = 0; d < Dimensions; d += 10)
            {
                int r = Random.GetInt(0, 255);
                int g = Random.GetInt(0, 255);
                int b = Random.GetInt(0, 255);
                int a = Random.GetInt(0, 255);

                double[] points = Random.GetDoubles(6, 0, _width);

                Position[d + 0] = r;
                Position[d + 1] = g;
                Position[d + 2] = b;
                Position[d + 3] = a;

                Position[d + 4] = points[0];
                Position[d + 5] = points[1];
                Position[d + 6] = points[2];
                Position[d + 7] = points[3];
                Position[d + 8] = points[4];
                Position[d + 9] = points[5];
            }

            Velocity = Random.GetDoubles(Dimensions, 0, 1);
        }

        public override void Update(params IParticle[] particles)
        {
            ImageCopyParticle globalBest = (ImageCopyParticle)particles.First();

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

        public override IParticle Clone()
        {
            IParticle clone = new ImageCopyParticle(Dimensions, _width);

            Position.CopyTo(clone.Position, 0);
            Velocity.CopyTo(clone.Velocity, 0);

            if (Fitness != null)
            {
                clone.Fitness = Fitness;
            }

            return clone;
        }
    }
}