
namespace Dart
{
    class Turns
    {

        private int throwone; // Fält
        private int throwtwo;
        private int throwthree;

        public Turns(int ThrowOne = 0, int ThrowTwo = 0, int ThrowThree = 0) // konstruktor med default värde
        {
            throwone = ThrowOne;
            throwtwo = ThrowTwo;
            throwthree = ThrowThree;
        }

        public int ThrowOne { get; set; } public int ThrowTwo { get; set; } public int ThrowThree { get; set; } // properties till fält

        public int Get_score() // metod lagrar summan av fälten och returerar summan
        {
            int total;
            total = throwone + throwtwo + throwthree;

            return total;
        }

        public override string ToString() // metod ToString returerar resultatet av pilarna
        {
            return string.Format("Första kastet: {0}, andra kastet: {1} och tredje kastet {2}", throwone, throwtwo, throwthree);
        }

    }

}


