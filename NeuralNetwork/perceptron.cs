namespace NeuralNetwork
{
    internal class Perceptron
    {
        static void Main(string[] args)
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
    }
}
