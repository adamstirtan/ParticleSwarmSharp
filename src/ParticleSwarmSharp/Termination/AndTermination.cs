namespace ParticleSwarmSharp.Termination
{
    public class AndTermination : LogicalOperatorTermination
    {
        public AndTermination(params ITermination[] terminations) : base(terminations)
        { }

        public override bool HasReached(IParticleSwarm particleSwarm)
        {
            return Terminations.All(x => x.HasReached(particleSwarm));
        }
    }
}