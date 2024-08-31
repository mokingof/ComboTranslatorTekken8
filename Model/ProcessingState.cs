using ComboTranslatorTekken8.Model.FSM;
using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.SpecialStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class ProcessingState : BaseState
    {
   
        public ProcessingState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            throw new NotImplementedException();
        }

        public override IState HandleInput(char input)
        {   //d f u b  
            //df db uf ub
            //qcf qcb 
            //ssl ssr swl swr ssc

            if (input.Equals('\0'))
            {
                return new InitialState(Context);
            }
            Context.Accumulator += input.ToString();

            if (QuarterCirclePattern.IsMatch(Context.Accumulator))
            {
                return new QuarterCircleDirectionState(Context);
            }
            else if (SideStepPattern.IsMatch(Context.Accumulator))
            {
                return new SideStepDirectionState(Context);
            }

           
            return this;

        }
    }
}
