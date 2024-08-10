namespace ComboTranslatorTekken8.Model.FSM
{
    public class StancesState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";

        public StancesState(ComboContext context)
        {
            this.context = context;        
        }

        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            return new Token(TokenType.Stances, accumulator, context.CurrentPosition);
        }

        public IState HandleInput(string input)
        {
            accumulator = input;
            return this;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
