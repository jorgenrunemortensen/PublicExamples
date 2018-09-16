using Logic;
using Model;
using System;

namespace Exercise1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var loader = new FileTriangleTreeModelLoader<int>("..\\..\\..\\Exercise-1.txt");
                var model = loader.LoadModel();
                var maxSum = ModelLogic.GetMaxSum(model, (n, c) => n.Value % 2 != c.Value % 2, out string path);
                Console.WriteLine($"Max sum = {maxSum}");
                Console.WriteLine($"Path = {path}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
