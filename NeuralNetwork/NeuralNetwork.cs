using System.Diagnostics;

namespace NeuralNetwork
{
    internal class NeuralNetwork
    {
        static void Main(string[] args)
        {
            BinaryPerceptron();
        }
        static void ClosingInPerceptron()
        {
            // Goal is to hit around 200.00

            double threshold;
            double currentWeightedSUM;
            Random r = new Random();

            double x1 = 10.00;
            double x2 = 10.00;
            double x3 = 10.00;

            double w1 = r.NextDouble() * 20 - 10;
            double w2 = r.NextDouble() * 20 - 10;
            double w3 = r.NextDouble() * 20 - 10;

            threshold = 200.0;

            double bias = r.NextDouble() * 2 - 1;

            currentWeightedSUM = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;

            double diff = threshold - currentWeightedSUM;

            Console.WriteLine($"Weighted SUM = {currentWeightedSUM}, Diff = {diff}");
            do
            {
                if (currentWeightedSUM < 200)
                {

                    double step = (diff / 30) * 0.1;

                    w1 += step;
                    w2 += step;
                    w3 += step;
                    bias += step;

                    currentWeightedSUM = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;
                    diff = threshold - currentWeightedSUM;

                    Console.WriteLine($"Weighted SUM = {currentWeightedSUM}, Diff = {diff}");
                    Thread.Sleep(10);
                }
                else
                {
                    double step = (Math.Abs(diff) / 30) * 0.1;

                    w1 -= step;
                    w2 -= step;
                    w3 -= step;
                    bias -= step;

                    currentWeightedSUM = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;
                    diff = threshold - currentWeightedSUM;

                    Console.WriteLine($"Weighted SUM = {currentWeightedSUM}, Diff = {diff}");
                    Thread.Sleep(10);
                }
            }
            while (currentWeightedSUM < 199.99 || currentWeightedSUM > 200.01);
        }

        static void BinaryPerceptron()
        {
            Random r = new Random();

            // Weights

            double w1 = r.NextDouble() * 2 - 1;
            double w2 = r.NextDouble() * 2 - 1;
            double w3 = r.NextDouble() * 2 - 1;
            double bias = r.NextDouble() * 2 - 1;

            double threshold = 0.5;
            double learningRate = 0.1;
            int totalErrors = 0;
            int epochs = 0;

            Console.WriteLine("Starting...\n");

            do
            {
                epochs++;

                for (int i = 0; i < 100; i++)
                {
                    // Random Input

                    int x1 = r.Next(0, 2);
                    int x2 = r.Next(0, 2);
                    int x3 = r.Next(0, 2);

                    // Only fire if all inputs are 1

                    int target = (x1 == 1 && x2 == 1 && x3 == 1) ? 1 : 0;

                    // Weighted Sum
                    double weightedSum = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;

                    // Make prediction 1 or 0
                    int prediction = weightedSum >= threshold ? 1 : 0;

                    // Calculate error
                    int error = target - prediction;

                    if (error != 0)
                    {
                        totalErrors++;

                        // Update weights and bias
                        w1 += x1 * error * learningRate;
                        w2 += x2 * error * learningRate;
                        w3 += x3 * error * learningRate;
                        bias += error * learningRate;
                    }


                }

                Console.WriteLine($"Epoch {epochs} | Total Errors:{totalErrors}");
            }
            while (epochs < 1000);

            // After training, test

            Console.WriteLine("\nTraining complete! Final predictions:\n");
            Console.WriteLine($"{"Inputs",-20} {"Target",-10} {"Predicted",-10} {"Result"}");
            Console.WriteLine(new string('-', 55));

            int[][] testCases = {
                new[] { 0, 0, 0 },
                new[] { 0, 0, 1 },
                new[] { 0, 1, 0 },
                new[] { 0, 1, 1 },
                new[] { 1, 0, 0 },
                new[] { 1, 0, 1 },
                new[] { 1, 1, 0 },
                new[] { 1, 1, 1 },
            };

            foreach (var test in testCases)
            {
                int x1 = test[0], x2 = test[1], x3 = test[2];
                int target = (x1 == 1 && x2 == 1 && x3 == 1) ? 1 : 0;

                double weightedSum = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;
                int prediction = weightedSum >= threshold ? 1 : 0;

                string result = prediction == target ? "Y" : "N";
                Console.WriteLine($"{x1},{x2},{x3,-17} {target,-10} {prediction,-10} {result}");
            }

        }
    }
}
