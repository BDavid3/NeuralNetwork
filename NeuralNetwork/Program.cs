namespace NeuralNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            int x1 = 1;
            int x2 = 2;
            int x3 = 3;
            // 3 inputs

            double threshold = 2.0;

            for (int i = 0; i < 9; i++)
            {
               double w1 = r.NextDouble() * 2 - 1;
               double w2 = r.NextDouble() * 2 - 1;
               double w3 = r.NextDouble() * 2 - 1;

               double bias = r.NextDouble() * 2 - 1;

                // 3 weights + bias

                double weightedSUM = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;
                // randomly generated weights changes the inputs randomly.

                if (weightedSUM >= threshold)
                {
                    Console.WriteLine($"SUM: {weightedSUM} -> Fired! (1)");
                }
                else
                {
                    Console.WriteLine($"SUM: {weightedSUM} -> Did not fire (0)");
                }
            }

        }
    }
}
