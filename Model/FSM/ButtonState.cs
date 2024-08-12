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
                context.SharedTokens.Add(new Token(TokenType.CombinedButton, Accumulator, context.CurrentPosition));
                context.CurrentPosition++;
            }
            else
            {
                for (int i = 0; i < Accumulator.Length; i++)
                {
                    if (Accumulator[i] == ' ')
                    {
                        continue;
                    }
                    context.SharedTokens.Add(new Token(TokenType.SingleButtons, Accumulator[i].ToString(), context.CurrentPosition));
                    context.CurrentPosition++;
                }
            }
        }
        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
        public void Reset()
        {
            Accumulator = "";
        }
    }
}
