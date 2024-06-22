using System;

namespace numberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo(); // get app information

            GreetUser(); // ask for user name and great 

            while (true)
            {
                // init hints number
                int hints = 1;

                // create random obj
                Random random = new Random();

                int correctNumber = random.Next(1, 100);

                // init guess var
                int guess = 0;


                // ask user for number
                Console.WriteLine("Guess a number between 1 and 100");
                Console.WriteLine(" (: You have 3 hints :) ");

                // while guess is not correct
                while (guess != correctNumber)
                {
                    string inputNum = Console.ReadLine();

                    // make sure it's a number
                    if (!int.TryParse(inputNum, out guess))
                    {
                        // print error message
                        PrintColorMessage(ConsoleColor.Red, "please Enter a number");

                        // keep going
                        continue;
                    }

                    // cast to int 
                    guess = Int32.Parse(inputNum);

                    if (guess != correctNumber)
                    {
                        // print faild message
                        PrintColorMessage(ConsoleColor.Red, "Wrong Number, please try again");

                        if(hints <= 3) {
                            Console.WriteLine("Use hint {0}? [Y or N]", hints);
                            string getHint = Console.ReadLine().ToUpper();
                            if (getHint == "Y")
                            {
                                Console.WriteLine("The number between {0} and {1}", (correctNumber - 12/hints), (correctNumber + 12 / hints));
                                hints++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No more hints");
                        }

                    }

                }

                // output success message 
                PrintColorMessage(ConsoleColor.Magenta, "You are correct :)  ");

                // Ask to play again
                Console.WriteLine("Play Again? [Y or N]");

                string ans = Console.ReadLine().ToUpper();

                if (ans == "Y")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
            // Get app informatio
            void GetAppInfo()
            {
                // setup var
                string appName = "Number Guesser";
                string appVersion = "1.0.1";
                string appAuthor = "Alaa Abdalqader";

                // change text color
                Console.ForegroundColor = ConsoleColor.Green;

                // write out app information
                Console.WriteLine("{0}: Version {1} by {2} ", appName, appVersion, appAuthor);

                // reset color 
                Console.ResetColor();

            }

            // Get users name 
            void GreetUser()
            {
                // Ask users name
                Console.WriteLine("What is your name");

                // Get user name
                string input = Console.ReadLine();

                Console.WriteLine("Hello {0}, lets play a game...", input);
            }

            // print color message
            void PrintColorMessage(ConsoleColor color, string message)
            {
                // change text color
                Console.ForegroundColor = color;

                // output faild message
                Console.WriteLine(message);

                // reset color 
                Console.ResetColor();
            }

        }
    }
}
