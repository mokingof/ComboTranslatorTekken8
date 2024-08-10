namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleDirectionState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";
        public SingleDirectionState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }
        public Token GenerateToken()
        {
            if (IsUpper(accumulator))
            {
                return new Token(TokenType.HoldSingleDirection, accumulator, context.CurrentPosition);

            }
            else
            {
                return new Token(TokenType.SingleDirection, accumulator, context.CurrentPosition);
            }
        }

        /*    public IState HandleInput(char input)
            {
                if (!char.IsDigit(input))
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
            }*/

        public IState HandleInput(string input)
        {
            accumulator = input;
            return this;
        }
        private bool IsUpper(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsUpper(c))
                    return false;
            }
            return true;
        }
        public void Reset()
        {
            accumulator = "";
        }
    }
}
