
namespace ComboTranslatorTekken8.Model.FSM
{
    public class ErrorState : IState
    {
        private readonly ComboContext context;
        public ErrorState(ComboContext context)
        {
            this.context = context;
        }

        public string Accumulator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public void GenerateToken()
        {
          
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
