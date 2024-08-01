namespace ComboTranslatorTekken8.Model
{
    public class ComboContext
    {
        private IState currentState;
        public List<Token> Tokens { get; private set; } = new List<Token>();
        public int CurrentPosition { get; private set; } = 0;

        public ComboContext()
        {
            currentState = new CurrentState(this);
        }
        public void ProcessInput(string input)
        {
            foreach (char c in input)
            {
                currentState = currentState.HandleInput(c);
                if (currentState is ErrorState)
                {
                    // Handle error state
                    break;
                }
            }
            // Generate final token if necessary
            var finalToken = currentState.GenerateToken();
            if (finalToken != null)
            {
                AddToken(finalToken);
            }
        }
        public void AddToken(Token token)
        {
            Tokens.Add(token);
            CurrentPosition++;
        }
        public void Reset()
        {
            Tokens.Clear();
            CurrentPosition = 0;
            currentState = new CurrentState(this);
        }
    }
}
