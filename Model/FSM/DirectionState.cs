namespace ComboTranslatorTekken8.Model.FSM
{
    public class DirectionState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n"};
        HashSet<string> HoldSingleDirection = new HashSet<string> {"D", "F", "U", "B", "N" };
        HashSet<string> HoldCombinedDirection = new HashSet<string> {"UF", "UB", "DF", "DB" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb" };
        public DirectionState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }
        public Token GenerateToken()
        {
           
            if (SingleDirection.Contains(accumulator))
            {
                return new Token(TokenType.SingleDirection, accumulator, context.CurrentPosition);
            }
            else if (HoldSingleDirection.Contains(accumulator))
            {
                return new Token(TokenType.HoldSingleDirection, accumulator, context.CurrentPosition);
            }
            if (CombinedDirection.Contains(accumulator))
            {
                return new Token(TokenType.CombinedDirection, accumulator, context.CurrentPosition);
            }
            else
            {
                return new Token(TokenType.HoldCombinedDirection, accumulator, context.CurrentPosition);
            }
        }

        public IState HandleInput(char input)
        {
            if (char.IsWhiteSpace(input))
            {
                return new InitialState(context);
            }
          else if (!char.IsDigit(input))
            {
                accumulator += input;
                return this;
            }
            else
            {
                GenerateToken();
                Reset();
                return new ButtonState(context);
            }
        }
        public void Reset()
        {
            accumulator = "";
        }
    }
}
