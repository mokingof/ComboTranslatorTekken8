using ComboTranslatorTekken8.Model.FSM;
using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text.RegularExpressions;



namespace ComboTranslatorTekken8.Model
{
    public class InitialState : BaseState
    {
        private static readonly Regex SingleDirectionPattern = new Regex(@"^[dfub]|[DFUB]$");
        public InitialState(ComboContext context) : base(context) { }
        public override void GenerateToken() { }
        public override IState HandleInput(char input)
        {
            if (char.IsDigit(input))
            {
                return new SingleButtonState(Context).HandleInput(input);
            }
            if (SingleDirectionPattern.IsMatch(input.ToString()))
            {
                return new SingleDirectionState(Context).HandleInput(input);
            }
            else
            {
                return new ProcessingState(Context).HandleInput(input);
            }
         
            
            
            //string type  = inputClassifier.ClassifyInput(input);    
            //IState state = stateFactory.CreateState(type,context);
            //return state.HandleInput(input);
           
        }
    }
}