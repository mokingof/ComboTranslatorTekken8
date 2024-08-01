namespace ComboTranslatorTekken8.Model
{
    public class CurrentState : IState
    {

        private readonly ComboContext context;
        public CurrentState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return null;
        }

 

        public Token GenerateToken()
        {
            return null;
        }

        public IState HandleInput(char input)
        {
            if (char.IsDigit(input))
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
