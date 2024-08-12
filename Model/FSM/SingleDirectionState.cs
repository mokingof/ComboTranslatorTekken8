namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleDirectionState : IState
    {
        private readonly ComboContext context;
       
        public SingleDirectionState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }
        public string Accumulator { get; set; } = "";

        public List<Token> GetTokens()
        {
            return context.SharedTokens;
        }
        public void GenerateToken()
        {
            /*if (IsUpper(Accumulator))
            {
                return new Token(TokenType.HoldSingleDirection, Accumulator, context.CurrentPosition);

            }
            else
            {
                return new Token(TokenType.SingleDirection, Accumulator, context.CurrentPosition);
            }*/
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
            Accumulator = input;
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
            Accumulator = "";
        }
    }
}
