using System.Text;

using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Events
{
    public class StoppedEventArgs : EventArgs
    {
        public StoppedEventArgs(IList<IParticle> solutions)
        {
            Solutions = solutions;
        }

        public IList<IParticle> Solutions { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"Solutions: ({Solutions.Count})");

            for (int i = 0; i < Solutions.Count; i++)
            {
                stringBuilder.AppendLine($"{i}: {string.Join(", ", Solutions[i].Position)}");
            }

            return stringBuilder.ToString();
        }
    }
}