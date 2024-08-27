using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
        private static readonly Regex CombinedDirectionPattern = new Regex(@"^[du][fb]$");

        public SingleDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            if (char.IsUpper(Context.Accumulator.ElementAt(0)))
            {
                AddToken(new Token(TokenType.HoldSingleDirection, Context.Accumulator, Context.CurrentPosition));
            }
            else
            {
                AddToken(new Token(TokenType.SingleDirection, Context.Accumulator, Context.CurrentPosition));
            }
            IsReadyForNextInput = false;
            ResetAccumulator();
        }
        public override IState HandleInput(char input)
        {
            if (input.Equals('\0'))
            {
                if (!IsEmptyString(Context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(Context);
            }
            if (!IsReadyForNextInput)
            {
                Context.Accumulator += input.ToString();
                IsReadyForNextInput = true;
                return this;
            }
            if (IsReadyForNextInput)
            {
                string first = Context.Accumulator;    
                string second =input.ToString();
                string total = first + second;
                if (CombinedDirectionPattern.IsMatch(total))
                {
                    return new CombinedDirectionState(Context).HandleInput(input);
                }
                else if (!CombinedDirectionPattern.IsMatch(total))
                {
                    GenerateToken();
                    return new InitialState(Context).HandleInput(input);
                }
                
            }
    

            return new ErrorState(Context);
        }

    }
}
