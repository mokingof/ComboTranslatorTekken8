using System.Text;

namespace ComboTranslatorTekken8.Model
{
    public class ButtonState : IState
    {
        private readonly ComboContext context;
        private StringBuilder accumulator = new StringBuilder();
        private HashSet<string> SingleButton = new HashSet<string> { "1", "2", "3", "4" };
        private HashSet<string> CombinedButton = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };


        public ButtonState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return SingleButton.Contains(input.ToString()) || input == '+';
        }

        public Token GenerateToken()
        {
            return new Token(TokenType.SingleButtons, "1", 0);
        }
        public IState HandleInput(char input)
        {
            return new DirectionState(context);

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
