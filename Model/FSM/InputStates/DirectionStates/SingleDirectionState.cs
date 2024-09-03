using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.InputStates.ButtonStates;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates
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
            else if (HandleNullOrTerminator(input))
            {
                return new InitialState(Context);
            }


            string first = Context.Accumulator;
            string second = input.ToString();
            string total = first + second;
            if (CombinedDirectionPattern.IsMatch(total))
            {
                return new CombinedDirectionState(Context).HandleInput(input);
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && char.IsDigit(input))
            {
                GenerateToken();
                return new SingleButtonState(Context).HandleInput(input);
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && SingleDirectionPattern.IsMatch(input.ToString()))
            {
                //  dbt bb! fbl! fc 
                GenerateToken();
                return new SingleDirectionState(Context).HandleInput(input);
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && !SingleDirectionPattern.IsMatch(input.ToString()))
            {
                return new ProcessingState(Context).HandleInput(input);

            }
            return new ErrorState(Context);
        }

    }
}
