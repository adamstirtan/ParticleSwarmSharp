using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Fitness
{
    public class FuncFitness : IFitnessFunction
    {
        private readonly Func<Particle, double> _function;

        public FuncFitness(Func<Particle, double> function)
        {
            _function = function;
        }

        public double Evaluate(Particle particle)
        {
            return _function(particle);
        }
    }
}