using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

namespace ParticleSwarmSharp
{
    public class ParticleSwarm : IParticleSwarm
    {
        private readonly IList<IParticle> _bestSolutions;

        private bool _isRunning;

        public ParticleSwarm(
            IPopulation population,
            IFitness fitness,
            ITermination termination)
        {
            Population = population;
            Fitness = fitness;
            Termination = termination;

            _bestSolutions = new List<IParticle>();

            Population.BestParticleChanged += PopulationBestParticleChanged;
        }

        private void PopulationBestParticleChanged(object? sender, EventArgs e)
        {
            var eventArgs = (BestParticleChangedEventArgs)e;

            _bestSolutions.Add(eventArgs.BestParticle);

            BestParticleChanged?.Invoke(this, e);
        }

        public TimeSpan RunTime { get; set; }

        public int IterationNumber { get; set; }

        public IPopulation Population { get; set; }

        public IFitness Fitness { get; set; }

        public ITermination Termination { get; set; }

        public IParticle BestParticle
        {
            get
            {
                if (Population.BestParticle == null)
                {
                    throw new Exception("Particles are not evaluated");
                }

                return Population.BestParticle;
            }
        }

        public event EventHandler? BestParticleChanged;

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

                OnStop(new StoppedEventArgs(_bestSolutions));
            }
        }

        protected virtual void OnBestParticleChanged(BestParticleChangedEventArgs e)
        {
            BestParticleChanged?.Invoke(this, e);
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
            foreach (IParticle particle in Population.Particles)
            {
                particle.Update(BestParticle);
            }

            EvaluateFitness();

            OnIterationComplete(new IterationEventArgs(++IterationNumber, BestParticle));

            return Termination.HasReached(this);
        }

        private void EvaluateFitness()
        {
            foreach (var particle in Population.Particles)
            {
                particle.Fitness = Fitness.Evaluate(particle);
            }

            IParticle bestParticle = Population.Particles
                .OrderBy(x => x.Fitness.GetValueOrDefault())
                .First();

            if (Population.BestParticle == null || bestParticle.Fitness < Population.BestParticle.Fitness)
            {
                Population.BestParticle = bestParticle.Clone();
            }
        }
    }
}