namespace GuesstheMap
{
    public class Program
    {
        public static int Difficulty = 1;
        public static int Tries = 0;
        public static int RandomNumber = 0;

        public static string Used_Numbers = "";
        static void Main(string[] args)
        {
            State();
        }

        public static void State()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lets Play a game of Guess The Number\n\n"); Thread.Sleep(1000);
            Console.WriteLine(" 1. Normal Difficulty (10)\n 2. Hard Difficulty (25)\n 3. Extreme Difficulty (100)\n");
            Console.ForegroundColor= ConsoleColor.White;
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                Difficulty = 1; Rules(); break;
                case "2":
                Difficulty = 2; Rules(); break;
                case "3":
                Difficulty = 3; Rules(); break;
            }
            State();
        }

        public static void Rules()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Yellow;
            if (Difficulty == 1 | Difficulty == 2) Console.WriteLine("You have 3 tries to get the Number!\n\n"); else Console.WriteLine("You have 10 tries to get the Number!\n\n");
            Thread.Sleep(2000); Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Setup();
        }

        public static void Setup()
        {
            switch (Difficulty)
            {
                case 1:
                    RandomNumber = Random_Number_Normal_Difficulty(); break;
                case 2:
                    RandomNumber += Random_Number_Hard_Difficulty(); break;
                case 3:
                    RandomNumber += Random_Number_Extreme_Difficulty(); break;
            }
            Play();
        }

        public static void Play()
        {
            if (Difficulty == 1 | Difficulty == 2 ) 
            {
                if (Tries < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Guess a Number:      Already used Numbers: {Used_Numbers}\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    var answerraw = Console.ReadLine();
                    int.TryParse(answerraw, out int answer);

                    Used_Numbers += $"{answer} ";

                    if (answer == RandomNumber)
                    {
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Good Job the Number was: {RandomNumber}  you took: {Tries} trys!");
                        Console.ReadLine(); Reset();
                    }
                    else
                    {
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nope that wasnt it!"); Tries += 1; Thread.Sleep(2000); Console.Clear(); Play();
                    }
                }
                else
                {
                    Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Sorry you didnt guess it within youre 3 tries! The Random Number was:  {RandomNumber}  Youre guessed Numbers were:  {Used_Numbers}");
                    Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(5000); Reset();
                }
            }
            else
            {
                if (Tries < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Guess a Number:        Already used Numbers: {Used_Numbers}\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    var answerraw = Console.ReadLine();
                    int.TryParse(answerraw, out int answer);

                    Used_Numbers += $"{answer} ";

                    if (answer == RandomNumber)
                    {
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Good Job the Number was: {RandomNumber}  you took: {Tries} trys!");
                        Console.ReadLine(); Reset();
                    }
                    else
                    {
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nope that wasnt it!"); Tries += 1; Thread.Sleep(2000); Console.Clear(); Play();
                    }
                }
                else
                {
                    Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Sorry you didnt guess it within youre 3 tries! The Random Number was:  {RandomNumber}  Youre guessed Numbers were:  {Used_Numbers}");
                    Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(5000); Reset();
                }
            }
        }

        public static void Reset()
        {
            Tries = 0;
            RandomNumber = 0;
            Difficulty = 1;
            Used_Numbers = "";
            State();
        }


        public static int Random_Number_Normal_Difficulty()
        {
            Random random = new Random();
            int number = random.Next(1,10);
            return number;
        }

        public static int Random_Number_Hard_Difficulty()
        {
            Random random = new Random();
            int number = random.Next(1, 25);
            return number;
        }


        public static int Random_Number_Extreme_Difficulty()
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            return number;
        }
    }
}
