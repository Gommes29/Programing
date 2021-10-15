using System;

namespace First_game_3_Mission_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();


            int score;
            int totalScore = 0;

            do
            {
                int d6 = random.Next(1, 7);
                score = d6;
                Console.WriteLine($"The player rolls:{score}");
                totalScore = totalScore + score;
            } 
            
            while (score < 6);





            Console.WriteLine($"Total score: {totalScore}");
        }
    }
}
