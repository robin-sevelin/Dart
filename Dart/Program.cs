using System;
using System.IO;

namespace Dart
{

    class Program
    {
        static void Main(string[] args)
        {
            
            Game myGame = new Game(); // skapar instans av klassen Game
            myGame.Playgame(); // metod anrop

            Console.WriteLine("Tryck för att avsluta..");
            Console.ReadLine();

        }

        
    }


}
