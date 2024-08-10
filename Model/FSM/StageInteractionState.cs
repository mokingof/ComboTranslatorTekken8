namespace ComboTranslatorTekken8.Model.FSM
{
    public class StageInteractionState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";

        public StageInteractionState(ComboContext context)
        {
            this.context = context;
        }
    
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            return new Token(TokenType.StageInteractions, accumulator, context.CurrentPosition);
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
