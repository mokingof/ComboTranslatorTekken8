
namespace ComboTranslatorTekken8.Model.FSM
{
    public class StancesState : IState
    {
        private readonly ComboContext context;
        
        public StancesState(ComboContext context)
        {
            this.context = context;
        }
        public string Accumulator { get; set; }

        public void AddToken(Token token)
        {
            throw new NotImplementedException();
        }

        public void GenerateToken()
        {
            throw new NotImplementedException();
        }

        public List<Token> GetTokens()
        {
            throw new NotImplementedException();
        }

        public IState HandleInput(string input)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
