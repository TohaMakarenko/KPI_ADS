using System;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "123";
            var result = SHA1Algorithm.SHA1(str);
            Console.WriteLine(string.Join("", result.Select(x => x.ToString("X"))));
        }
    }
}
