namespace ComboTranslatorTekken8.Model.FSM
{
    public class ErrorState : IState
    {
        private readonly ComboContext context;
        public ErrorState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            throw new NotImplementedException();
        }

        public IState HandleInput(char input)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
