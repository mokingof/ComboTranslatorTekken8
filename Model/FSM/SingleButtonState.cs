using System.Text;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleButtonState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";


        public SingleButtonState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return input == '+';
        }

        public Token GenerateToken()
        {
            return new Token(TokenType.SingleButtons, accumulator, context.CurrentPosition);

        }

        public IState HandleInput(string input)
        {
            accumulator = input;
            return this;
        }

        /*  public IState HandleInput(char input)
          {
              if (char.IsDigit(input) || CanCombineWith(input))
              {
                  accumulator += input;
                  return this;
              }
              else
              {
                  GenerateToken();
                  return new DirectionState(context);
              }
          }*/



        public void Reset()
        {
            accumulator = "";
        }
    }
}
