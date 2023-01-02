using ParticleSwarmSharp;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

IPopulation population = new Population(25);

IFitnessFunction fitness = new FuncFitness((particle) =>
{
    //double x = particle.[0];

    return Math.Pow(/*x*/5, 2);
});

IParticleSwarm pso = new ParticleSwarm(
    population,
    fitness,
    new GenerationCountTermination(3));

pso.GenerationComplete += (s, e) =>
{
    Console.WriteLine("Generation complete");
};

pso.TerminationCriteriaReached += (s, e) =>
{
    Console.WriteLine("Termination criteria reached");
};

pso.Stopped += (s, e) =>
{
    Console.WriteLine("Stopped");
};

pso.Start();