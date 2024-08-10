namespace ComboTranslatorTekken8.Model.FSM
{
    public class ComboContext
    {
        private IState initialState;
        public List<Token> Tokens { get; private set; } = new List<Token>();
        public int CurrentPosition { get; private set; } = 0;

        public ComboContext()
        {
            initialState = new InitialState(this);
        }
        public void ProcessInput(string input)
        {
        
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    // Generate token for the current state before moving to a new one
                    Token token = initialState.GenerateToken();
                    if (token != null)
                    {
                        AddToken(token);
                    }
                    initialState = new InitialState(this);
                    continue;
                }
                initialState = initialState.HandleInput(c);

                if (initialState is ErrorState)
                {
                    // Handle error state
                    break;
                }
            }
            // Generate final token if necessary
            Token finalToken = initialState.GenerateToken();
            if (finalToken != null)
            {
                AddToken(finalToken);
            }
        }
        private void AddToken(Token token)
        {
            Tokens.Add(token);
            CurrentPosition++; 
        }
        public void Reset()
        {
            Tokens.Clear();
            CurrentPosition = 0;
            initialState = new InitialState(this);
        }

        public List<Token> GetTokens()
        {
            return Tokens;
        }
    }
}
