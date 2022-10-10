using System;
using System.Collections.Generic;
using System.IO;

namespace Dart
{
    class Game
    {
        private List<Player> player_list = new List<Player>(); // Lista för mänskliga spelare
        private List<Cpu> cpu_list = new List<Cpu>(); // Lista för cpu spelare

        Random slumptal = new Random();

        int kast1;
        int kast2;
        int kast3;

        int totalPlayerScore = 0; // startvärde för spelarpoäng
        int totalCpuScore = 0; // startvärde för cpu poäng
        int cpuPlayer = 0; // startvärde för antal spelare cpu spelare
        int antalSpelare = 0; // startvärde för antal mänskliga spelare

        bool loop = true; // villkor för loop

        public void Playgame() // metod, startar spelet
        {

            Console.WriteLine("Välkommen till Dart spelet");
            Console.WriteLine("...........................");
            Console.WriteLine("Hur många spelare är det som spelar?");
            try
            {
                antalSpelare = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("..använd hela siffror");

            }

            for (int i = 0; i < antalSpelare; i++)
            {
                Console.WriteLine("Skriv in namnet på spelaren");
                string playerName = Console.ReadLine();
                Add_Player(playerName); // metodanrop för att lägga till spelare
            }

            if (antalSpelare < 2) // villkor, om mänskliga spelare är mindre än 2 så läggs en cpu spelare till
            {
                Console.WriteLine("En Cpu spelare har joinat spelet..");
                Console.WriteLine(".............................");
                Console.WriteLine("Skriv namnet på Cpu spelaren");
                string cpuName = Console.ReadLine();
                cpuPlayer++; // öka cpu spelare med 1
                Add_Cpu(cpuName); // metdanrop för att lägga till cpu

            }

            do
            {

                foreach (var player in player_list) // matar ut antal gånger som spelare i spelarlista
                {
                    Console.WriteLine("Tryck enter för att {0} ska kasta sin första pil", player);
                    Console.ReadLine();
                    kast1 = slumptal.Next(0, 21);
                    Console.WriteLine("Tryck enter för att {0} ska kasta sin andra pil", player);
                    Console.ReadLine();
                    kast2 = slumptal.Next(0, 21);
                    Console.WriteLine("Tryck enter för att {0} ska kasta sin tredje pil", player);
                    Console.ReadLine();
                    kast3 = slumptal.Next(0, 21);

                    player.Add_turn(kast1, kast2, kast3); // metodanrop, lägger till poängen i poäng listan 
                    totalPlayerScore = player.Calculate_Total(); // metodanrop, räkna ut totalpoäng för spelaren

                    foreach (var turn in player_list) // skriver ut poäng i poänglista
                    {
                        turn.Print_score(); // metodanrop, skriver ut poänglistan

                        if (totalPlayerScore > 301) // villkor, om totalpoängen överskrider 301
                        {
                            Console.WriteLine("Spelaren {0} har vunnit", player); // skriver ut spelarens namn
                            Console.WriteLine("Tryck för att avsluta");
                            Console.ReadLine();
                            loop = false; // avslutar loop
                        }
                    }

                }

                if (cpuPlayer > 0) // villkor, om cpu spelare är fler än noll
                {
                    Console.WriteLine("Tryck för att Cpun ska kasta");
                    Console.ReadLine();
                    Console.Clear();

                    foreach (var cpu in cpu_list) // matar ut antal gånger som cpu'er i cpu lista
                    {
                        Console.WriteLine("Cpu'n {0} börjar kasta sina pilar", cpu);
                        /* datorn kastar per automatik med 3 sekunders nedräkning */
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("..om 3");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("..2");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("..1");
                        System.Threading.Thread.Sleep(1000);

                        kast1 = slumptal.Next(0, 21);
                        kast2 = slumptal.Next(0, 21);
                        kast3 = slumptal.Next(0, 21);

                        cpu.Add_turn(kast1, kast2, kast3); // metodanrop, poäng läggs till i poänglista
                        totalCpuScore = cpu.Calculate_Total(); // metodanrop, räknar ut total poängen

                        foreach (var turn in cpu_list) // matar ut poäng i poänglistan
                        {
                            turn.Print_score(); // metodanrop, skriver ut poängen

                            if (totalCpuScore > 301) // villkor om cpun's poäng överskrider 301
                            {
                                Console.WriteLine("Spelaren {0} har vunnit", cpu);
                                Console.WriteLine("Tryck för att avsluta");
                                Console.ReadLine();
                                loop = false; // avslutar loop
                            }
                        }

                    }

                }
                Console.WriteLine("Tryck enter för att köra nästa omgång");
                Console.ReadLine();
                Console.Clear();


            } while (loop); // villkor för loop

        }




        public void Add_Player(string name) // metod för att lägga till spelare
        {

            Player players = new Player(name); // skapar instans för klassen Player
            player_list.Add(players); // lägger till spelare i spelarlista
        }

        public void Add_Cpu(string name) // metod för att lägga till cpu
        {
            Cpu cpus = new Cpu(name); // skapar instans för klassen Cpu
            cpu_list.Add(cpus); // lägger till cpu i cpulista
        }


    }

}
