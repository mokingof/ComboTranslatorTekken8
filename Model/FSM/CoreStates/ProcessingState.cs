using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.MiscStates;
using ComboTranslatorTekken8.Model.FSM.SpecialStates;

namespace ComboTranslatorTekken8.Model.FSM.CoreStates
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
            //bb! b1


            Context.Accumulator += input.ToString();

            if (QuarterCirclePattern.IsMatch(Context.Accumulator))
            {
                return new QuarterCircleDirectionState(Context);
            }
            else if (SideStepPattern.IsMatch(Context.Accumulator))
            {
                return new SideStepDirectionState(Context);
            }
            else if (StageInteraction.IsMatch(Context.Accumulator))
            {
                return new StageInteractionState(Context);
            }


            return this;

        }
    }
}
