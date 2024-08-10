namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedInput : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";

        public CombinedInput(ComboContext context)
        {
            this.context = context;
        }
    
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            throw new NotImplementedException();
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
