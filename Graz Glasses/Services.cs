namespace Graz_Glass;

public static class Services
{
    public static int GetUserInput(string prompt, int minValue, int maxValue)
    {
        int value;
        do
        {
            Console.Write(prompt);
            value = int.Parse(Console.ReadLine());
        } while (value < minValue || value > maxValue);

        return value;
    }

    public static double[][] InitializePyramid(int size)
    {
        double[][] pyramid = new double[size][];
        for (int i = 0; i < size; i++)
        {
            pyramid[i] = new double[i + 1];
        }
        return pyramid;
    }

    public static double SimulateWaterFlow(double[][] pyramid, int targetRow, int targetGlass)
    {
        double inflowRate = 1.0; // Water flow per second
        double time = 0;

        while (time <= 10000) // Protection against infitity-loop
        {
            time += 0.001;
            AddWaterToTop(pyramid, inflowRate * 0.001);

            // Check if targeted glas over flows
            if (pyramid[targetRow - 1][targetGlass - 1] >= 10.0)
            {
                return time;
            }

            SpreadWater(pyramid);
        }
        return -1;
    }

    private static void AddWaterToTop(double[][] pyramid, double inflowRate)
    {
        pyramid[0][0] += inflowRate;
    }

    public static void SpreadWater(double[][] pyramid)
    {
        for (int i = 0; i < pyramid.Length - 1; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (pyramid[i][j] > 10.0)
                {
                    double overflow = pyramid[i][j] - 10.0;
                    pyramid[i][j] = 10.0;
                    pyramid[i + 1][j] += overflow / 2.0;
                    pyramid[i + 1][j + 1] += overflow / 2.0;
                }
            }
        }
    }
}