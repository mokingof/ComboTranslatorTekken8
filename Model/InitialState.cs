using ComboTranslatorTekken8.Model.FSM;
using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;



namespace ComboTranslatorTekken8.Model
{
    public class InitialState : BaseState
    {
        public InitialState(ComboContext context) : base(context) { }
        public override void GenerateToken() { }
        public override IState HandleInput(char input)
        {
            if (char.IsDigit(input))
            {
                return new SingleButtonState(context).HandleInput(input);
            }
            if (char.IsLetter(input))
            {
                return new ProcessingState(context).HandleInput(input);
            }
            return new ErrorState(context);
            
            
            //string type  = inputClassifier.ClassifyInput(input);    
            //IState state = stateFactory.CreateState(type,context);
            //return state.HandleInput(input);
           
        }
    }
}