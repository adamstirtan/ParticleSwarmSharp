using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Events
{
    public class BestParticleChanged : EventArgs
    {
        public IParticle? BestParticle { get; set; }

        public BestParticleChanged(IParticle? bestParticle)
        {
            BestParticle = bestParticle;
        }
    }
}