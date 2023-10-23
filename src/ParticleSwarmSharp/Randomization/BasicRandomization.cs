namespace ParticleSwarmSharp.Randomization
{
    public class BasicRandomization : Randomization
    {
        private static ThreadLocal<Random> _threadRandom = new(NewRandom);

        private static readonly Random _globalRandom = new();
        private static readonly object _globalLock = new();
        private static int? _seed;

        private static Random Instance => _threadRandom.Value;

        private static Random NewRandom()
        {
            lock (_globalLock)
            {
                return new Random(_seed ?? _globalRandom.Next());
            }
        }

        public static void ResetSeed(int? seed)
        {
            _seed = seed;
            _threadRandom = new ThreadLocal<Random>(NewRandom);
        }

        public override int GetInt(int min, int max)
        {
            return Instance.Next(min, max);
        }

        public override float GetFloat()
        {
            return (float)Instance.NextDouble();
        }

        public override double GetDouble()
        {
            return Instance.NextDouble();
        }

        public override double GetDouble(double min, double max)
        {
            return Instance.NextDouble() * Math.Abs(max - min) + min;
        }
    }
}