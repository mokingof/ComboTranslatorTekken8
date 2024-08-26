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
            else
            {
                return new SingleDirectionState(context).HandleInput(input);
            }
            //string type  = inputClassifier.ClassifyInput(input);    
            //IState state = stateFactory.CreateState(type,context);
            //return state.HandleInput(input);
           
        }
    }
}