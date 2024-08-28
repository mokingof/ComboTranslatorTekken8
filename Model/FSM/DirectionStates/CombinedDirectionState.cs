using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }
        private static readonly Regex CombinedDirectionPattern = new Regex(@"^[dfub]|[DFUB]$");

        public override void GenerateToken()
        {
            if (char.IsUpper(Context.Accumulator.ElementAt(0)))
            {
                AddToken(new Token(TokenType.HoldCombinedDirection, Context.Accumulator, Context.CurrentPosition));
            }
            else
            {
                AddToken(new Token(TokenType.CombinedDirection, Context.Accumulator, Context.CurrentPosition));
            }
            IsReadyForNextInput = false;
            ResetAccumulator();
        }
        public override IState HandleInput(char input)
        {
            if (!IsReadyForNextInput)
            {
                Context.Accumulator += input.ToString();
                IsReadyForNextInput = true;
                return this;
            }

            if (IsReadyForNextInput)
            {
                if (CombinedDirectionPattern.IsMatch(Context.Accumulator))
                {
                    GenerateToken();
                    return new InitialState(Context).HandleInput(input);
                }
                else if (!CombinedDirectionPattern.IsMatch(Context.Accumulator))
                {
                    return new InitialState(Context).HandleInput(input);
                }
            }

            return new ErrorState(Context);

        }
    }
}
