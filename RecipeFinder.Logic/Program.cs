using System;
using System.Text;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.Logic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Recipe Finder starting...");

            var repo = new Repository();
            Console.WriteLine(repo.ListAllUsers());
            repo.AddNewUser();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(repo.ListAllUsers());
        }
    }
}