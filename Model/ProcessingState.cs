using ComboTranslatorTekken8.Model.FSM;
using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class ProcessingState : BaseState
    {
        private static readonly Regex SingleDirectionPattern = new Regex(@"^[dfub]$");
        private static readonly Regex CombinedDirectionPattern = new Regex(@"^[du][fb]$");
        private static readonly Regex QuarterCirclePattern = new Regex(@"^qc[fb]$");
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
            //qcf qcb hcf hcb
            //ssl ssr swl swr ssc

            if (input.Equals('\0'))
            {
                return new InitialState(Context);
            }
            if (string.IsNullOrEmpty(Context.Accumulator))
            {
                Context.Accumulator += input.ToString();
                // IsReadyForNextInput = true;
                return this;
            }

           /* if (SingleDirectionPattern.IsMatch(Context.Accumulator))
            {
                if (char.IsDigit(input))
                {
                    return new SingleDirectionState(Context).HandleInput(input);
                }
                
            }*/

            return new ErrorState(Context);
        }
    }
}
