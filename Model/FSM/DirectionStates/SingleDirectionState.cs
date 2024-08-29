using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
       
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

            if (HandleInitialInput(input))
            {
                return this;
            }

            if (HandleNullOrTerminator(input))
            {
                return new InitialState(Context);
            }
            if (IsReadyForNextInput)
            {
                string first = Context.Accumulator;
                string second = input.ToString();
                string total = first + second;
                if (CombinedDirectionPattern.IsMatch(total))
                {
                    return new CombinedDirectionState(Context).HandleInput(input);
                }
                else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && SingleDirectionPattern.IsMatch(input.ToString()))
                {
                    GenerateToken();
                    return new SingleDirectionState(Context).HandleInput(input);
                }
                else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && !SingleDirectionPattern.IsMatch(input.ToString()))
                {
                    GenerateToken();
                    return new InitialState(Context).HandleInput(input);
                }
            }
            return new ErrorState(Context);
        }

    }
}
