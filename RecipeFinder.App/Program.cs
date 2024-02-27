using System;

namespace RecipeFinder
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            await Menu.ExecuteMenu();
            //await APIReader.Reader();
        }
    }

}
