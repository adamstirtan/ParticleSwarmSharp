using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParticleSwarmSharp.Fitness;

namespace ParticleSwarmSharp
{
    public abstract class OptimizationProblem : IOptimizationProblem
    {
        public OptimizationProblem(IFitnessFunction fitnessFunction)
        {
        }
    }
}