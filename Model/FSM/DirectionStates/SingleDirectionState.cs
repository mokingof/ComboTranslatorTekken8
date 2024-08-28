using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
        private static readonly Regex CombinedDirectionPattern = new Regex(@"^[dfub]|[DFUB]$");
        private static readonly Regex SingleDirectionPattern = new Regex(@"^[dfub]$");
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
                if (SingleDirectionPattern.IsMatch(Context.Accumulator) && SingleDirectionPattern.IsMatch(input.ToString()))
                {
                    GenerateToken();
                    return new SingleDirectionState(Context).HandleInput(input);
                }
                if (SingleDirectionPattern.IsMatch(Context.Accumulator) && !SingleDirectionPattern.IsMatch(input.ToString()))
                {
                    GenerateToken();
                    return new InitialState(Context).HandleInput(input);
                }

                string first = Context.Accumulator;    
                string second =input.ToString();
                string total = first + second;
                if (CombinedDirectionPattern.IsMatch(total))
                {
                    return new CombinedDirectionState(Context).HandleInput(input);
                }                
            }
            return new ErrorState(Context);
        }

    }
}
