namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleDirectionState : IState
    {
        private readonly ComboContext context;
       
        public SingleDirectionState(ComboContext context)
        {
            this.context = context;
        }

        public string Accumulator { get; set; } = "";

        public List<Token> GetTokens()
        {
            return context.SharedTokens;
        }
        public void GenerateToken()
        {
            if (char.IsUpper(Accumulator,0))
            {
                AddToken(new Token(TokenType.HoldSingleDirection, Accumulator, context.CurrentPosition));
            }
            else
            {
                AddToken(new Token(TokenType.SingleDirection, Accumulator, context.CurrentPosition));
            }
        }
        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
        public void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }
        public void Reset()
        {
            Accumulator = "";
        }
    }
}
