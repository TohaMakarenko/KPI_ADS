using System;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sha = new SHA1Algorithm();
            System.Console.WriteLine(string.Join("", sha.SHA1("123").Select(x => x.ToString("X"))));
        }
    }
}
