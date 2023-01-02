using System.Text;

using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Events
{
    public class IterationEventArgs : EventArgs
    {
        public IterationEventArgs(int iterationNumber, IParticle bestParticle)
        {
            IterationNumber = iterationNumber;
            BestParticle = bestParticle;
        }

        public int IterationNumber { get; set; }

        public IParticle BestParticle { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append($"Iteration:\t{IterationNumber}\n");
            stringBuilder.Append($"Fitness:\t{BestParticle.Fitness}\n");
            stringBuilder.Append($"Solution:\t{string.Join(", ", BestParticle.Position)}");
            stringBuilder.Append('\n');

            return stringBuilder.ToString();
        }
    }
}