using System;
using System.Collections.Generic;
using System.IO;

namespace Dart
{
    class Cpu
    {
        private List<CpuTurns> cpu_turn_list = new List<CpuTurns>(); // lista för poäng för spelare

        private string name; // Fält

        public Cpu(string Name = "") // konstruktor med default värde
        {
            name = Name;
        }

        public string Name { get; set; } // properties för fält

        public void Add_turn(int tal1, int tal2, int tal3) // metod för att lägga till poäng i poäng lista
        {
            cpu_turn_list.Add(new CpuTurns(tal1, tal2, tal3));
        }
        public int Calculate_Total() // metod för att räkna ut totalpoängen
        {
            int total = 0;
            foreach (var turn in cpu_turn_list)
            {
                total += turn.Get_score();
            }
            return total;
        }
        public void Print_score() // metod för att skriva ut poänglistan
        {
            foreach (var turn in cpu_turn_list)
            {
                Console.Clear();
                Console.WriteLine("\nstatistik över kast för {0}", name);
                Console.WriteLine("..............................");
                Console.WriteLine(turn);
                Console.WriteLine("..............................");
                Console.WriteLine("Totalpoängen för spelaren är {0} poäng ", Calculate_Total());
                Console.WriteLine("..............................");

            }
            try
            {
                using (StreamWriter sw = new StreamWriter("poäng.txt", true))
                {
                    foreach (var turn in cpu_turn_list)
                    {
                        sw.Write("\n Cpu poäng: " + turn);
                        
                    }

                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString() // metod ToString returerar strängen från konstruktorn som är en tom sträng
        {
            return string.Format(name);
        }
    }
}
