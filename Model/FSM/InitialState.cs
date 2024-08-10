using ComboTranslatorTekken8.Model.FSM;

namespace ComboTranslatorTekken8.Model
{
    public class InitialState : IState
    {

        private readonly ComboContext context;
        public InitialState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return false;
        }

 

        public Token GenerateToken()
        {
            return null;
        }
        public IState HandleInput(char input)
        {
            if (char.IsWhiteSpace(input))
            {
                return this;
            }
         else  if (char.IsDigit(input))
            {
                return new ButtonState(context).HandleInput(input);
            }
            else if (char.IsLetter(input))
            {
                return new DirectionState(context).HandleInput(input);
            }
            else
            {
                return new ErrorState(context);
            }

        }

        public void Reset(){}
    }
}
