using System.Text;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleButtonState : IState
    {
        private readonly ComboContext context;


        public SingleButtonState(ComboContext context)
        {
            this.context = context;
        }

        public string Accumulator { get; set; } = "";

        public bool CanCombineWith(char input)
        {
            return input == '+';
        }

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

          /*  if (!input.Contains("+") && input.Length > 1)
            {
                Accumulator = string.Join(" ", input.Select(c => c.ToString()));
            }*/
            foreach (char c in input)
            {
                Accumulator += c;
            }

            return this;
        }
        public void Reset()
        {
            Accumulator = "";
        }
    }
}
