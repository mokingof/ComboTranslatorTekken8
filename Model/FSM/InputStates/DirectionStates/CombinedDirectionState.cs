using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.CoreStates;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }
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
            if (HandleInitialInput(input))
            {
                return this;
            }
            else if (HandleNullOrTerminator(input))
            {
                return new InitialState(Context);
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
