namespace ParticleSwarmSharp
{
    public class ParticleSwarmOptions
    {
        public int PopulationSize { get; set; } = 100;

        public int Iterations { get; set; } = 1000;

        public double Inertia { get; set; }

        public double Cognitive { get; set; }

        public double Social { get; set; }

        public Topologies Topology { get; set; }
    }
}
