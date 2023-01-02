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

        public IParticle BestParticle => _population.BestParticle;

        public event EventHandler? GenerationComplete;

        public event EventHandler? TerminationCriteriaReached;

        public event EventHandler? Stopped;

        public void Start()
        {
            if (_isRunning)
            {
                throw new Exception();
            }

            _isRunning = true;

            EvaluateFitness();

            bool terminationCriteriaReached;

            do
            {
                terminationCriteriaReached = EvolveOneGeneration();
            }
            while (!terminationCriteriaReached);

            OnTerminationCriteriaReached(new TerminationReachedEventArgs());
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

        protected virtual void OnGenerationComplete(GenerationEventArgs e)
        {
            GenerationComplete?.Invoke(this, e);
        }

        protected virtual void OnTerminationCriteriaReached(TerminationReachedEventArgs e)
        {
            TerminationCriteriaReached?.Invoke(this, e);
        }

        protected virtual void OnStop(StoppedEventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        private bool EvolveOneGeneration()
        {
            foreach (IParticle particle in _population.CurrentGeneration.Particles)
            {
                particle.Update(BestParticle);
            }

            _population.CreateGeneration();

            return EndCurrentGeneration();
        }

        private bool EndCurrentGeneration()
        {
            EvaluateFitness();

            _population.EndGeneration();

            OnGenerationComplete(new GenerationEventArgs(
                _population.GenerationNumber, BestParticle));

            return _terminationCriteria.HasReached(this);
        }

        private void EvaluateFitness()
        {
            if (_population.CurrentGeneration == null)
            {
                throw new Exception();
            }

            foreach (var particle in _population.CurrentGeneration.Particles)
            {
                particle.Fitness = _fitnessFunction.Evaluate(particle);
            }

            _population.BestParticle = _population.CurrentGeneration.Particles
                .OrderBy(x => x.Fitness.GetValueOrDefault())
                .First();
        }
    }
}