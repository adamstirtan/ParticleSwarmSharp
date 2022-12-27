using ParticleSwarmSharp.Fitness;

namespace ParticleSwarmSharp
{
    public class ParticleSwarm : IParticleSwarm
    {
        private readonly ParticleSwarmOptions _options;
        private readonly IFitnessFunction _fitnessFunction;
        private readonly List<Particle> _particles;

        private bool _isRunning;
        private Particle _globalBest;

        public ParticleSwarm(
            ParticleSwarmOptions options,
            IFitnessFunction fitnessFunction)
        {
            _options = options;
            _fitnessFunction = fitnessFunction;

            _particles = new List<Particle>(_options.PopulationSize);

            for (int i = 0; i < _options.PopulationSize; i++)
            {
                _particles[i] = new Particle(
                    _options.Inertia,
                    _options.Cognitive,
                    _options.Social,
                    _fitnessFunction.Dimensions);
            }
        }

        public TimeSpan RunTime => throw new NotImplementedException();

        public event EventHandler? IterationChanged;

        public event EventHandler? IterationComplete;

        public event EventHandler? TerminationCriteriaReached;

        public event EventHandler? Stopped;

        public OptimizationResult Start()
        {
            if (_isRunning)
            {
                throw new Exception("Optimization is already running");
            }

            _isRunning = true;

            OptimizationResult result = new();

            for (int iteration = 0; iteration < _options.Iterations; iteration++)
            {
                foreach (Particle particle in _particles)
                {
                    particle.Update();
                }

                OnIterationChanged(new IterationEventArgs(iteration));
            }

            return result;
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