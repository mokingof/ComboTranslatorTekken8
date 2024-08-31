using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.Interface;
namespace ComboTranslatorTekken8.Model.FSM.Context
{
    public class ComboContext
    {
        private IState _initialState;
        public List<Token> SharedTokens { get; private set; } = new List<Token>();
        public int CurrentPosition { get; set; } = 0;
        public string Accumulator { get; set; } = "";
        public ComboContext()
        {
            _initialState = new InitialState(this);
        }
        public void ProcessInput(string input)
        {
            /*   string[] tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

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

               }*/

            foreach (char c in input)
            {
                _initialState = _initialState.HandleInput(c);
            }
            FinalizeProcessing();
        }

        private void FinalizeProcessing()
        {
            // This method can be used to generate any pending tokens
            // or perform any cleanup operations
            _initialState.HandleInput('\0'); // Send a null character to signify end of input
        }

        public List<Token> GetTokens()
        {
            return SharedTokens;
        }
    }
}
