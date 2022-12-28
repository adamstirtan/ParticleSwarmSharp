namespace ParticleSwarmSharp.Populations
{
    public class Population : IPopulation
    {
        public DateTime CreatedAt => throw new NotImplementedException();

        public Particle BestParticle => throw new NotImplementedException();

        public event EventHandler BestParticleChanged;

        public void CreateInitialGeneration()
        {
            throw new NotImplementedException();
        }

        public void EndGeneration()
        {
            throw new NotImplementedException();
        }
    }
}