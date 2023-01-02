namespace ParticleSwarmSharp.Randomization
{
    public abstract class Randomization : IRandomization
    {
        public abstract int GetInt(int min, int max);

        public virtual int[] GetInts(int length, int min, int max)
        {
            int[] values = new int[length];

            for (int i = 0; i < length; i++)
            {
                values[i] = GetInt(min, max);
            }

            return values;
        }

        public virtual int[] GetUniqueInts(int length, int min, int max)
        {
            int difference = max - min;

            if (difference < length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(length),
                    $"The length is {length} but the possible values between {min} (inclusive) and {max} (exclusive) are {difference}.");
            }

            var orderedValues = Enumerable.Range(min, difference).ToList();
            var values = new int[length];

            for (int i = 0; i < length; i++)
            {
                int removeIndex = GetInt(0, orderedValues.Count);
                values[i] = orderedValues[removeIndex];
                orderedValues.RemoveAt(removeIndex);
            }

            return values;
        }

        public abstract float GetFloat();

        public virtual float GetFloat(float min, float max)
        {
            return min + ((max - min) * GetFloat());
        }

        public abstract double GetDouble();

        public abstract double GetDouble(double min, double max);

        public virtual double[] GetDoubles(int length, double min, double max)
        {
            double[] values = new double[length];

            for (int i = 0; i < length; i++)
            {
                values[i] = GetDouble(min, max);
            }

            return values;
        }
    }
}