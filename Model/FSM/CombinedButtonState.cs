namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedButtonState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";

       public CombinedButtonState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            return new Token(TokenType.CombinedButton, accumulator, context.CurrentPosition);
        }

        public IState HandleInput(string input)
        {
           /* foreach (char c in input)
            {
                accumulator += c;   
            }*/
            accumulator = input;
            return this;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
