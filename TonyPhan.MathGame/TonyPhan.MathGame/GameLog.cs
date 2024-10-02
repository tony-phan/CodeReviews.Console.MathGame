namespace MathGame
{
    public class GameLog
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operation { get; set; }
        public int Answer { get; set; }
        public int UserAnswer { get; set; }
        public string Result { get; set; }

        public GameLog(int Operand1, int Operand2, string Operation, int Answer, int UserAnswer, string Result)
        {
            this.Operand1 = Operand1;
            this.Operand2 = Operand2;
            this.Operation = Operation;
            this.Answer = Answer;
            this.UserAnswer = UserAnswer;
            this.Result = Result;
        }

        public override string ToString()
        {
            return $"Question: {Operand1} {Operation} {Operand2} = ?\tAnswer: {Answer}\tYou Answered: {UserAnswer}\t\tResult: {Result}";
        }
    }
}