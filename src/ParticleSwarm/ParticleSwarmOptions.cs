namespace ParticleSwarm
{
    public class ParticleSwarmOptions
    {
        public int PopulationSize { get; set; } = 100;

        public int Iterations { get; set; } = 1000;

        public Topologies Topology { get; set; }
    }
}
