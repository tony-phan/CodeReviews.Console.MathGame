namespace MathGame
{
    public class Game
    {
        public static Random random = new Random();
        public int correct { get; set; }
        public int incorrect { get; set; }
        public int totalQuestions { get; set; }
        public List<GameLog> history { get; set; }

        public Game(List<GameLog> history)
        {
            this.correct = 0;
            this.incorrect = 0;
            this.totalQuestions = 0;
            this.history = history;
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
                        operand1 = random.Next(0, 16);
                        operand2 = random.Next(0, 16);
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
            this.history.Add(new GameLog(operand1, operand2, operation, answer, userAnswer, result));
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
            Console.WriteLine($"SCORE\nCorrect: {correct}\tWrong: {incorrect}\t Total Questions: {totalQuestions}");
        }

        public void DisplayGameHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("No game history");
            }
            else
            {
                foreach (GameLog gameLog in history)
                {
                    Console.WriteLine(gameLog.ToString());
                }
            }
        }

        private void UpdateScore(string result)
        {
            totalQuestions += 1;
            if(result == "Correct")
            {
                correct += 1;
            } else
            {
                incorrect += 1;
            }
        }
    }
}