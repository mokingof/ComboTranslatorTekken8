namespace ComboTranslatorTekken8.Model.FSM
{
    public abstract class BaseState : IState
    {
        protected readonly ComboContext context;

        protected BaseState(ComboContext context)
        {
            this.context = context;
        }
        public string Accumulator { get; set; } = "";
        public abstract void GenerateToken();
        public abstract IState HandleInput(string input);

        public virtual void Reset()
        {
            Accumulator = "";
        }

        public virtual List<Token> GetTokens()
        {
            return context.SharedTokens;
        }

        public virtual void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }
    }
}
