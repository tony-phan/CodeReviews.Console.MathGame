namespace MathGame
{
    public class Game
    {
        public static Random random = new Random();
        public int Correct { get; set; }
        public int Incorrect { get; set; }
        public int TotalQuestions { get; set; }
        public List<GameLog> History { get; set; }

        public Game(List<GameLog> history)
        {
            this.Correct = 0;
            this.Incorrect = 0;
            this.TotalQuestions = 0;
            this.History = history;
        }

        public void PerformOperation(string operation)
        {
            int operand1 = random.Next(0, 16);
            int operand2 = random.Next(0, 16);
            int answer = 0;

            switch (operation)
            {
                case "+":
                    answer = operand1 + operand2;
                    break;
                case "-":
                    answer = operand1 - operand2;
                    break;
                case "*":
                    answer = operand1 * operand2;
                    break;
                case "/":
                    while (operand2 == 0 || (operand1 % operand2) != 0)
                    {
                        operand1 = random.Next(0, 100);
                        operand2 = random.Next(0, 100);
                    }
                    answer = operand1 / operand2;
                    break;
                default:
                    Console.WriteLine("Wrong operation");
                    return;
            }

            Console.WriteLine($"{operand1} {operation} {operand2} = ?");
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            string result = answer == userAnswer ? "Correct" : "Wrong";
            Console.WriteLine(result);
            this.UpdateScore(result);
            this.History.Add(new GameLog(operand1, operand2, operation, answer, userAnswer, result));
        }

        public void ShowGameMenu()
        {
            Console.WriteLine("Welcome to the Cool Game!: \n" +
                "\t1. Addition (+)\n" +
                "\t2. Subtraction (-)\n" +
                "\t3. Multiplication (*)\n" +
                "\t4. Division (/)\n" +
                "\t5. View Game History\n" +
                "\t6. Exit");
        }

        public void ShowGameScore()
        {
            Console.WriteLine($"SCORE\nCorrect: {Correct}\tWrong: {Incorrect}\tTotal Questions: {TotalQuestions}");
        }

        public void DisplayGameHistory()
        {
            if (History.Count == 0)
            {
                Console.WriteLine("No game history");
            }
            else
            {
                Console.WriteLine("Question\tAnswer\tYou Answered\tResult");
                foreach (GameLog gameLog in History)
                {
                    Console.WriteLine(gameLog.ToString());
                }
            }
        }

        private void UpdateScore(string result)
        {
            TotalQuestions += 1;
            if(result == "Correct")
            {
                Correct += 1;
            } else
            {
                Incorrect += 1;
            }
        }
    }
}