using System.Diagnostics;

namespace NeuralNetwork
{
    internal class NeuralNetwork
    {
        static void Main(string[] args)
        {
            SigmoidPerceptron();
        }
        static void SigmoidPerceptron()
        {
            Random random = new Random();

            // Weights

            double w1 = random.NextDouble() * 2 - 1;
            double w2 = random.NextDouble() * 2 - 1;
            double w3 = random.NextDouble() * 2 - 1;

            // Saver
            double bias = random.NextDouble() * 2 - 1;

            // Learning Rate
            double learningRate = 0.1;

            // epochs
            int epochs = 0;

            do
            {
                // Input

                int x1 = random.Next(0, 2);
                int x2 = random.Next(0, 2);
                int x3 = random.Next(0, 2);

                // Epochs
                epochs++;

                // Target
                int target = (x1 == 1 && x2 == 1 && x3 == 1) ? 1 : 0;

                // Weighted Sum
                double weightedSum = (x1 * w1) + (x2 * w2) + (x3 * w3) + bias;

                // Sigmoid
                double sigmoidOutput = Sigmoid(weightedSum);

                // Predict 1 or 0 -> for user
                int prediction = sigmoidOutput >= 0.5 ? 1 : 0;

                // Error

                double error = target - sigmoidOutput;

                // Console output for debugging
                Console.WriteLine($"Epoch {epochs} | Target: {target} | Prediction: {prediction} | Error: {error} | Weights: ({w1}, {w2}, {w3}) | Bias: {bias}");

                // Update weights and bias

                w1 += x1 * error * learningRate;
                w2 += x2 * error * learningRate;
                w3 += x3 * error * learningRate;
                bias += error * learningRate;
            }
            while (epochs < 10000);
        }
        static double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));
    }
}
