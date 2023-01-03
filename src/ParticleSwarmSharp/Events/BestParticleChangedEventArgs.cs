using System.Text;

using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Events
{
    public class BestParticleChangedEventArgs : EventArgs
    {
        public IParticle BestParticle { get; set; }

        public BestParticleChangedEventArgs(IParticle bestParticle)
        {
            BestParticle = bestParticle;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("Best particle updated!");
            stringBuilder.AppendLine($"Fitness: {BestParticle.Fitness}");
            stringBuilder.AppendLine($"Position: {string.Join(", ", BestParticle.Position)}");

            return stringBuilder.ToString();
        }
    }
}