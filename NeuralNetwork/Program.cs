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

            for (int i = 0; i < 9; i++)
            {
               int w1 = r.Next(-1, 2);
               int w2 = r.Next(-1, 2);
               int w3 = r.Next(-1, 2);
               // 3 weights

               int weightedSUM = (x1 * w1) + (x2 * w2) + (x3 * w3);
               // randomly generated weights changes the inputs randomly.

                Console.Write($"{weightedSUM}, ");
            }

        }
    }
}
