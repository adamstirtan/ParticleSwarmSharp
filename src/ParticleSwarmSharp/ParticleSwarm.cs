using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

namespace ParticleSwarmSharp
{
    public class ParticleSwarm : IParticleSwarm
    {
        private readonly IPopulation _population;
        private readonly IFitnessFunction _fitnessFunction;
        private readonly ITermination _terminationCriteria;

        private bool _isRunning;

        public ParticleSwarm(
            IPopulation population,
            IFitnessFunction fitnessFunction,
            ITermination terminationCriteria)
        {
            _population = population;
            _fitnessFunction = fitnessFunction;
            _terminationCriteria = terminationCriteria;
        }

        public TimeSpan RunTime => throw new NotImplementedException();

        public Particle BestParticle => throw new NotImplementedException();

        public event EventHandler? GenerationComplete;

        public event EventHandler? TerminationCriteriaReached;

        public event EventHandler? Stopped;

        public void Start()
        {
            if (_isRunning)
            {
                throw new Exception("Optimization is already running");
            }

            _isRunning = true;

            bool terminationCriteriaReached;

            do
            {
                terminationCriteriaReached = EvolveOneGeneration();
            }
            while (!terminationCriteriaReached);
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;

                OnStop(new EventArgs());
            }
        }

        protected virtual void OnGenerationComplete(GenerationEventArgs e)
        {
            GenerationComplete?.Invoke(this, e);
        }

        protected virtual void OnStop(EventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        private bool EvolveOneGeneration()
        {
            _population.EndGeneration();

            return EndCurrentGeneration();
        }

        private bool EndCurrentGeneration()
        {
            return false;
        }
    }
}