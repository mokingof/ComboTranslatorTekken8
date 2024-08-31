using ComboTranslatorTekken8.Model.FSM;
using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class ProcessingState : BaseState
    {

       
        private static readonly Regex HalfCirclePattern = new Regex(@"^hc[fb]$");
        private static readonly Regex SideStepPattern = new Regex(@"^ss[lr]|sw[lr]$");
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
                return new SpecialDirectionState(Context);
            }

           
            return this;

        }
    }
}
