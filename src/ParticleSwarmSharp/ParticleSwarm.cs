using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;

namespace ParticleSwarmSharp
{
    public class ParticleSwarm : IParticleSwarm
    {
        private readonly IPopulation _population;
        private readonly IFitnessFunction _fitnessFunction;

        private bool _isRunning;
        private Particle _globalBest;

        public ParticleSwarm(
            IPopulation population,
            IFitnessFunction fitnessFunction)
        {
            _population = population;
            _fitnessFunction = fitnessFunction;
        }

        public TimeSpan RunTime => throw new NotImplementedException();

        public event EventHandler? IterationChanged;

        public event EventHandler? IterationComplete;

        public event EventHandler? TerminationCriteriaReached;

        public event EventHandler? Stopped;

        public OptimizationResult Start()
        {
            //if (_isRunning)
            //{
            //    throw new Exception("Optimization is already running");
            //}

            //_isRunning = true;

            //OptimizationResult result = new();

            //for (int iteration = 0; iteration < _options.Iterations; iteration++)
            //{
            //    foreach (Particle particle in _particles)
            //    {
            //        particle.Update();
            //    }

            //    OnIterationChanged(new IterationEventArgs(iteration));
            //}

            //return result;
            return null;
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;

                OnStop(new EventArgs());
            }
        }

        protected virtual void OnIterationChanged(IterationEventArgs e)
        {
            IterationChanged?.Invoke(this, e);
        }

        protected virtual void OnStop(EventArgs e)
        {
            Stopped?.Invoke(this, e);
        }
    }
}