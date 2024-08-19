using System.Text;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedInput : IState
    {
        private readonly ComboContext context;

        public CombinedInput(ComboContext context)
        {
            this.context = context;
        }
        public string Accumulator { get; set; } = "";
        public void GenerateToken()
        {

        }
        public List<Token> GetTokens()
        {
            return context.SharedTokens;
        }
        public IState HandleInput(string input)
        {
            var groups = Regex.Matches(input, @"(\d+(?:\+\d+)*)|([a-zA-Z]+)")
                             .Cast<Match>()
                             .Select(m => m.Value);

            foreach (var group in groups)
            {
                ProcessGroup(group);
            }

            return this;
        }
        private void ProcessGroup(string group)
        {
            if (char.IsDigit(group[0]))
            {
                ProcessButtonInput(group);
            }
            else
            {
                ProcessDirectionInput(group);
            }
        }
        private void ProcessButtonInput(string input)
        {
            var tokenType = input.Contains("+") ? TokenType.CombinedButton : TokenType.SingleButtons;
            AddToken(new Token(tokenType, input, context.CurrentPosition));
        }
        private void ProcessDirectionInput(string input)
        {
            var tokenType = input.Length > 1 ? TokenType.CombinedDirection : TokenType.SingleDirection;
            AddToken(new Token(tokenType, input, context.CurrentPosition));
        }
        public void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }
        public void Reset()
        {

        }
    }
}
