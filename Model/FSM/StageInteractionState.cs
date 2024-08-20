
namespace ComboTranslatorTekken8.Model.FSM
{
    public class StageInteractionState : IState
    {
        private readonly ComboContext context;

        public StageInteractionState(ComboContext context)
        {
            this.context = context;
        }  
        public string Accumulator { get; set; }

        public void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }

        public void GenerateToken()
        {
            AddToken(new Token(TokenType.StageInteractions, Accumulator.ToString(), context.CurrentPosition));
        }

        public List<Token> GetTokens()
        {
           return context.SharedTokens;
        }

        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }

        public void Reset()
        {
            Accumulator = "";
        }
    }
}
