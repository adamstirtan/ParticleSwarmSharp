using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Fitness
{
    public class FuncFitness : IFitnessFunction
    {
        private readonly Func<IParticle, double> _function;

        public FuncFitness(Func<IParticle, double> function)
        {
            _function = function;
        }

        public double Evaluate(IParticle particle)
        {
            return _function(particle);
        }
    }
}