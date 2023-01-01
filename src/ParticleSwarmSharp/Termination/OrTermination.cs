namespace ParticleSwarmSharp.Termination
{
    public class OrTermination : LogicalOperatorTermination
    {
        public OrTermination(params ITermination[] terminations) : base(terminations)
        { }

        public override bool HasReached(IParticleSwarm particleSwarm)
        {
            return Terminations.Any(x => x.HasReached(particleSwarm));
        }
    }
}