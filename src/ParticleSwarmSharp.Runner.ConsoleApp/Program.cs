using ParticleSwarmSharp;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Randomization;
using ParticleSwarmSharp.Termination;

IRandomization random = new BasicRandomization();

int populationSize = 25;
int dimensions = 1;
double minX = -10;
double maxX = 10;

var particles = new List<IParticle>();

for (int i = 0; i < populationSize; i++)
{
    ClassicParticle particle = new(dimensions)
    {
        Position = random.GetDoubles(dimensions, minX, maxX),
        Velocity = random.GetDoubles(dimensions, 0, 1)
    };

    particles.Add(particle);
}

IPopulation population = new Population(particles);

IFitness fitness = new FuncFitness(candidate =>
{
    double x = candidate.Position[0];

    return Math.Pow(x, 2);
});

IParticleSwarm pso = new ParticleSwarm(
    population,
    fitness,
    new FitnessStagnationTermination(20));

pso.BestParticleChanged += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.GenerationComplete += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.TerminationReached += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Stopped += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Start();