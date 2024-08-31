using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM
{
    public abstract class BaseState : IState
    {
        protected readonly ComboContext Context;
        //  protected static InputClassifier inputClassifier;
        //  protected static StateFactory stateFactory;
        public bool IsReadyForNextInput = false;
        public static readonly Regex CombinedDirectionPattern = new Regex(@"^(df|db|uf|ub)$", RegexOptions.IgnoreCase);
        public static readonly Regex SingleDirectionPattern = new Regex(@"^[dfub]$", RegexOptions.IgnoreCase);
        public static readonly Regex QuarterCirclePattern = new Regex(@"^qc[fb]$", RegexOptions.IgnoreCase);
        public static readonly Regex SideStepPattern = new Regex(@"^ss[lr]|sw[lr]$", RegexOptions.IgnoreCase);
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
        protected bool HandleInitialInput(char input)
        {
            if (!IsReadyForNextInput)
            {
                Context.Accumulator += input.ToString();
                IsReadyForNextInput = true;
                return true;
            }
            return false;
        }
        protected bool HandleNullOrTerminator(char input)
        {
            if (input.Equals('\0'))
            {
                if (!IsEmptyString(Context.Accumulator))
                {
                    GenerateToken();
                }
                return true;
            }
            return false;
        }
        public  void AddToken(Token token)
        {
            Context.SharedTokens.Add(token);
            Context.CurrentPosition++;
        }
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
    }
}
