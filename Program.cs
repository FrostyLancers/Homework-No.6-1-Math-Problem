using System;
using System.Diagnostics;

namespace Homework_Struct__Enum_No._6
{
    class Program
    {
        static void Main(string[] args)
        {
            int Level = 0;
            decimal OverallScore = 0;
            Console.WriteLine("Score: 0, Difficulty: Easy");
            
            while (true)
            {
                Console.WriteLine("Press [0] to Play Game.");
                Console.WriteLine("Press [1] to set difficulty.");
                Console.WriteLine("Press [2] to exit.");
                Console.Write("Options: ");
                int Options = int.Parse(Console.ReadLine());

                if (Options < 0 || Options > 2)
                {                  
                    Console.WriteLine("Please input 0-2.");
                }
                else
                {
                    switch (Options)
                    {
                        case 0:
                            Console.WriteLine("OverallScore: " + OverallScore);
                            decimal ScoreFromThisGame = PlayGame(Level);
                            Console.WriteLine("Score from this Game: " + ScoreFromThisGame);
                            OverallScore = OverallScore + ScoreFromThisGame;
                            Console.WriteLine("OverallScore: {0}, Difficulty: {1}." , OverallScore, (Difficulty)Level);
                            break;
                        case 1:
                            DifficultySetting(ref Level);
                            break;
                        case 2:
                            return;
                    }
                }
            }
        }

        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }

        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }

      
        static decimal PlayGame(int Level)
        {
            while (true)
            {
                int NumofQuestions = 0;
                if (Level == 0)
                {
                    NumofQuestions = NumofQuestions + 3;
                }
                else if (Level == 1)
                {
                    NumofQuestions = NumofQuestions + 5;
                }
                else if (Level == 2)
                {
                    NumofQuestions = NumofQuestions + 7;
                }

                Stopwatch stopwatch = new Stopwatch();

                Problem[] Questions = GenerateRandomProblems(NumofQuestions);
                int CorrectAnswer = 0;

                stopwatch.Start();
                for (int i = 0; i < NumofQuestions; i++)
                {
                    Console.WriteLine(Questions[i].Message);
                    Console.Write("Ans: ");
                    int Ans = int.Parse(Console.ReadLine());

                    if (Questions[i].Answer == Ans)
                    {
                        CorrectAnswer++;
                    }
                }
                stopwatch.Stop();

                Console.WriteLine("Correct Answer: " + CorrectAnswer);
               
                double Seconds = stopwatch.ElapsedMilliseconds/1000;
                double SecondsButFloor = Math.Floor(Seconds);
                Console.WriteLine("Time Used: {0} seconds." , SecondsButFloor);

                decimal Score = CalculateScore(CorrectAnswer, NumofQuestions, SecondsButFloor, Level);
                return Score;
            }
        }


        static decimal CalculateScore(int CorrectAnswer, int NumofQuestions, double SecondsButFloor, int Level)
        {
            decimal First = (decimal)CorrectAnswer / (decimal)NumofQuestions;
            
            decimal Second = 25 - (Level * Level);
            decimal Second2 = Second / Math.Max((decimal)SecondsButFloor,Second);
            
            decimal Third = ((2 * Level) + 1) * ((2 * Level) + 1);
            
            decimal Score1 = First * Second2 * Third;

            return Score1;
        }
        
       
        static int DifficultySetting(ref int Level)
        {
            while (true)
            {
                Console.WriteLine("Please input the new Difficulty");
                Console.WriteLine("Press [0] to set to Easy.");
                Console.WriteLine("Press [1] to set to Normal");
                Console.WriteLine("Press [2] to set to Hard");
                Console.Write("Change to: ");
                int ChangeTo = int.Parse(Console.ReadLine());
               
                if (ChangeTo < 0 || ChangeTo > 2)
                {
                    Console.WriteLine("Please input 0 - 2.");
                }
                else if (ChangeTo == 0)
                {
                    Console.WriteLine("Your Current Difficulty is [{0}]." , (Difficulty)ChangeTo);
                    Level = ChangeTo;
                    return Level;
                }
                else if (ChangeTo == 1)
                {
                    Console.WriteLine("Your Current Difficulty is [{0}]." , (Difficulty)ChangeTo);
                    Level = ChangeTo;
                    return Level;
                }
                else if (ChangeTo == 2)
                {
                    Console.WriteLine("Your Current Difficulty is [{0}].", (Difficulty)ChangeTo);
                    Level = ChangeTo;
                    return Level;
                }
            }           
        }
    }
}
