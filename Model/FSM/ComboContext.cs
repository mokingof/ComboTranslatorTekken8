namespace ComboTranslatorTekken8.Model.FSM
{
    public class ComboContext
    {
        private IState initialState;
        public List<Token> SharedTokens { get; private set; } = new List<Token>();
        public int CurrentPosition { get;  set; } = 0;

        public ComboContext()
        {
            initialState = new InitialState(this);
        }
        public void ProcessInput(string input)
        {
            string[] tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                initialState = initialState.HandleInput(tokens[i]);
                initialState.GenerateToken();
                if (initialState is ErrorState)
                {
                    // Handle error state
                    Console.WriteLine($"Error processing token: {tokens[i]}");
                    break;
                }
                initialState = new InitialState(this);
            }

        }   
        public void Reset()
        {
            SharedTokens.Clear();
            CurrentPosition = 0;
            initialState = new InitialState(this);
        }
        public List<Token> GetTokens()
        {
            return SharedTokens;
        }
    }
}
