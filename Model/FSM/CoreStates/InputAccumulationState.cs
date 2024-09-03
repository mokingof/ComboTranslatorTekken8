using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.CoreStates
{
    public class InputAccumulationState : BaseState
    {
        public InputAccumulationState(ComboContext context) : base(context) {}

        public override void GenerateToken() {}

        public override IState HandleInput(char input)
        {
            Context.Accumulator += input.ToString();

            if (OnlyOnceCheck(Context.Accumulator) && !input.Equals('!'))
            {
                return new SingleDirectionState(Context); 
            }
            else if (OnlyOnceCheck(Context.Accumulator) && input.Equals('!'))
            {
           
                return new ProcessingState(Context).HandleInput(input);
            }


            return new InitialState(Context);
        }


        public bool OnlyOnceCheck(string s)
        {
            return s.Length >= 2 && s.Length <= 3 && s.Distinct().Count() == 1;
        }
    }
}
