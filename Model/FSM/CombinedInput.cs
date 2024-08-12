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
            string buttonPart = "";
            string directionPart = "";

            foreach (char c in input)
            {
                if (char.IsDigit(c) || c.Equals('+'))
                {
                    buttonPart += c;
                }
                else if (char.IsLetter(c))
                {
                    directionPart += c;
                }
            }
          /*  // Process direction part
            if (!string.IsNullOrEmpty(directionPart))
            {
                IState directionState = new SingleDirectionState(context).HandleInput(directionPart);
                context.AddToken(directionState.GenerateToken());
            }
            // Process button part
            if (!string.IsNullOrEmpty(buttonPart))
            {
                IState buttonState = new SingleButtonState(context).HandleInput(buttonPart);
                context.AddToken(buttonState.GenerateToken());
            }*/

            return this;
        }


        public void Reset()
        {

        }
    }
}
