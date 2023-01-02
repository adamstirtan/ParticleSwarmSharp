﻿using System.Text;

using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Events
{
    public class GenerationEventArgs : EventArgs
    {
        public GenerationEventArgs(int generationNumber, IParticle bestParticle)
        {
            GenerationNumber = generationNumber;
            BestParticle = bestParticle;
        }

        public int GenerationNumber { get; set; }

        public IParticle BestParticle { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append($"{DateTime.Now.ToShortTimeString()} - Generation: {GenerationNumber}\n");
            stringBuilder.Append($"Fitness:\t{BestParticle.Fitness}\n");
            stringBuilder.Append($"Solution:\t{string.Join(", ", BestParticle.Position)}");
            stringBuilder.Append('\n');

            return stringBuilder.ToString();
        }
    }
}