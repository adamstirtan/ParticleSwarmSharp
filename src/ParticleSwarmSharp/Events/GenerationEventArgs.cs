namespace ParticleSwarmSharp.Events
{
    public class GenerationEventArgs : EventArgs
    {
        public GenerationEventArgs(int generation)
        {
            Generation = generation;
        }

        public int Generation { get; set; }
    }
}