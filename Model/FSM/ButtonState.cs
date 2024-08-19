using System.Text;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class ButtonState : IState
    {
        private readonly ComboContext context;

        public ButtonState(ComboContext context)
        {
            this.context = context;
        }

        public string Accumulator { get; set; } = "";

        public List<Token> GetTokens()
        {
            return context.SharedTokens;
        }
        public void GenerateToken()
        {
            if (Accumulator.Contains("+"))
            {
                AddToken(new Token(TokenType.CombinedButton, Accumulator, context.CurrentPosition));
            }
            else
            {
                for (int i = 0; i < Accumulator.Length; i++)
                {
                    if (Accumulator[i] == ' ')
                    {
                        continue;
                    }
                    AddToken(new Token(TokenType.SingleButtons, Accumulator[i].ToString(), context.CurrentPosition));
                }
            }
        }
        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
        public void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }
        public void Reset()
        {
            Accumulator = "";
        }
    }
}
