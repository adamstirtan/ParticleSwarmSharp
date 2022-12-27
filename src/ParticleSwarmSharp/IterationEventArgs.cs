namespace ParticleSwarmSharp
{
    public class IterationEventArgs : EventArgs
    {
        public IterationEventArgs(int iteration)
        {
            Iteration = iteration;
        }

        public int Iteration { get; set; }
    }
}
