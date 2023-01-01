namespace ParticleSwarmSharp.Termination
{
    public abstract class LogicalOperatorTermination : ITermination
    {
        protected IList<ITermination> Terminations;

        protected LogicalOperatorTermination(params ITermination[] terminations)
        {
            Terminations = new List<ITermination>(terminations);
        }

        public void AddTermination(ITermination termination)
        {
            Terminations.Add(termination);
        }

        public abstract bool HasReached(IParticleSwarm particleSwarm);
    }
}