using ParticleSwarmSharp;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

int populationSize = 3;

List<ClassicParticle> particles = new();

for (int i = 0; i < populationSize; i++)
{
    particles.Add(new ClassicParticle(1));
}

IPopulation population = new Population(populationSize);

population.CreateGeneration(particles);

IFitnessFunction fitness = new FuncFitness((particle) =>
{
    double x = particle.Position[0];

    return -1 * Math.Pow(x, 2);
});

IParticleSwarm pso = new ParticleSwarm(
    population,
    fitness,
    new GenerationCountTermination(5));

pso.GenerationComplete += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.TerminationCriteriaReached += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Stopped += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Start();