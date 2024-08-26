namespace ComboTranslatorTekken8.Model.FSM
{
    public abstract class BaseState : IState
    {
        protected readonly ComboContext context;
      //  protected static InputClassifier inputClassifier;
      //  protected static StateFactory stateFactory;
        protected BaseState(ComboContext context)
        {
            this.context = context;
          //  InitializeSharedComponents();
        }
        public string Accumulator { get; set; } = "";
        public abstract void GenerateToken();
        public abstract IState HandleInput(char input);

        public virtual void Reset()
        {
            Accumulator = "";
        }
   /*     private static void InitializeSharedComponents()
        {
            if (inputClassifier == null)
            {
                inputClassifier = new InputClassifier();
            }
            if (stateFactory == null)
            {
                stateFactory = new StateFactory();
            }
        }*/

        public virtual void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
        }
    }
}
