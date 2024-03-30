namespace CIT_195_Lesson_8_Delegates_Events
{
    // create a delegate
    public delegate void RaceDelegate(int n);
    public class Race
    {
        // create a delegate event object
        public event RaceDelegate victory;
        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // invoke the delegate event object and pass champ to the method
            victory(champ);
        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with the footRace event
            round1.victory += footRace;
            // trigger the event
            round1.Racing(10, 5);
            // register with the carRace event
            round1.victory -= footRace;
            round1.victory += carRace;
            //trigger the event
            round1.Racing(10, 50);
            // register a bike race event using a lambda expression
            round1.victory -= carRace;
            round1.victory += (winner) => Console.WriteLine($"Bicyclist number {winner} is the winner!");
            // trigger the event
            round1.Racing(10, 20);
        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner!");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Runner number {winner} is the winner!");
        }
    }
}
