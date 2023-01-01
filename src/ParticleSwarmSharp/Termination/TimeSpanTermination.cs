namespace ParticleSwarmSharp.Termination
{
    public class TimeSpanTermination : ITermination
    {
        public TimeSpan MaxTime { get; set; }

        public TimeSpanTermination(TimeSpan timeSpan)
        {
            MaxTime = timeSpan;
        }

        public bool HasReached(IParticleSwarm particleSwarm)
        {
            return particleSwarm.RunTime >= MaxTime;
        }
    }
}