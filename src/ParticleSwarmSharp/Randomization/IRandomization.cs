namespace ParticleSwarmSharp.Randomization
{
    public interface IRandomization
    {
        int GetInt(int min, int max);

        int[] GetInts(int length, int min, int max);

        int[] GetUniqueInts(int length, int min, int max);

        float GetFloat();

        float GetFloat(float min, float max);

        double GetDouble();

        double GetDouble(double min, double max);

        double[] GetDoubles(int length, double min, double max);
    }
}