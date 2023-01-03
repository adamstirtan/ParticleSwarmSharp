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

        public int IterationNumber { get; set; }

        public IParticle BestParticle
        {
            get
            {
                if (_population.BestParticle == null)
                {
                    throw new Exception("Particles are not evaluated");
                }

                return _population.BestParticle;
            }
        }

        public event EventHandler? GenerationComplete;

        public event EventHandler? TerminationReached;

        public event EventHandler? Stopped;

        public void Start()
        {
            if (_isRunning)
            {
                throw new Exception();
            }

            _isRunning = true;

            IterationNumber = 0;
            EvaluateFitness();

            bool terminationReached;

            do
            {
                terminationReached = Iteration();
            }
            while (!terminationReached);

            OnTerminationReached(new TerminationReachedEventArgs());
            Stop();
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;

                OnStop(new StoppedEventArgs());
            }
        }

        protected virtual void OnIterationComplete(IterationEventArgs e)
        {
            GenerationComplete?.Invoke(this, e);
        }

        protected virtual void OnTerminationReached(TerminationReachedEventArgs e)
        {
            TerminationReached?.Invoke(this, e);
        }

        protected virtual void OnStop(StoppedEventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        private bool Iteration()
        {
            foreach (IParticle particle in _population.Particles)
            {
                particle.Update(BestParticle);
            }

            EvaluateFitness();

            OnIterationComplete(new IterationEventArgs(++IterationNumber, BestParticle));

            return _terminationCriteria.HasReached(this);
        }

        private void EvaluateFitness()
        {
            foreach (var particle in _population.Particles)
            {
                particle.Fitness = _fitnessFunction.Evaluate(particle);
            }

            _population.BestParticle = _population.Particles
                .OrderBy(x => x.Fitness.GetValueOrDefault())
                .First();
        }
    }
}