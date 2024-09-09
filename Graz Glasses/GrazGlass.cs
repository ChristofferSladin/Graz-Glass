namespace Graz_Glass;

public static class GrazGlass
{
    public static void Run()
    {
        int row = Services.GetUserInput("Ange rad (2 ≤ r ≤ 50): ", 2, 50);
        int glass = Services.GetUserInput("Ange glas (1 ≤ g ≤ r): ", 1, row);

        double[][] pyramid = Services.InitializePyramid(51);
        double timeToOverflow = Services.SimulateWaterFlow(pyramid, row, glass);

        if (timeToOverflow > 0)
            Console.WriteLine($"Glas ({row}, {glass}) börjar rinna över efter {timeToOverflow:F3} sekunder.");
        else
            Console.WriteLine("Simulationen tog för lång tid, något gick fel.");
    }
}