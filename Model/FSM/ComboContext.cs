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
            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                initialState = initialState.HandleInput(tokens[i]);

                if (initialState is ErrorState)
                {
                    // Handle error state
                    Console.WriteLine($"Error processing token: {tokens[i]}");
                    break;
                }

                // Generate token for the current state after processing each input
                Token token = initialState.GenerateToken();
                if (token != null)
                {
                    AddToken(token);
                }

                // Reset to initial state for the next token
                initialState = new InitialState(this);
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
