using System.Text;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class ButtonState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";
        private HashSet<string> singleButton = new HashSet<string> { "1", "2", "3", "4" };
        private HashSet<string> combinedButton = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };


        public ButtonState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return input == '+';
        }

        public Token GenerateToken()
        {
            if (singleButton.Contains(accumulator))
            {
                return new Token(TokenType.SingleButtons, accumulator, context.CurrentPosition);
            }
            else
            {
                return new Token(TokenType.CombinedButton, accumulator, context.CurrentPosition);
            }
            
        }
        public IState HandleInput(char input)
        {
            if (char.IsWhiteSpace(input))
            {
                return new InitialState(context);
            }
            else if (char.IsDigit(input) || CanCombineWith(input))
            {
                accumulator += input;
                return this;
            }
            else
            {
                GenerateToken();
                return new DirectionState(context);
            }
        }

        public void Reset()
        {
            accumulator = "";
        }
    }
}
