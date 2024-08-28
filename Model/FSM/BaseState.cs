namespace ComboTranslatorTekken8.Model.FSM
{
    public abstract class BaseState : IState
    {
        protected readonly ComboContext Context;
        //  protected static InputClassifier inputClassifier;
        //  protected static StateFactory stateFactory;
        public bool IsReadyForNextInput = false;
        protected BaseState(ComboContext context)
        {
            this.Context = context;
          //  InitializeSharedComponents();
        }
      
        public abstract void GenerateToken();
        public abstract IState HandleInput(char input);

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
        public bool IsEmptyString(string input)
        {
            return string.IsNullOrEmpty(input);
        }
        public char GetEndCharacter(string input)
        {
            return Context.Accumulator[Context.Accumulator.Length - 1];
        }


        public void ResetAccumulator()
        {
            Context.Accumulator = "";
        }
        public  void AddToken(Token token)
        {
            Context.SharedTokens.Add(token);
            Context.CurrentPosition++;
        }
    }
}
