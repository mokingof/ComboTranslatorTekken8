using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.ButtonStates
{
    public class CombinedButtonState : BaseState
    {
        public CombinedButtonState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedButton, Context.Accumulator, Context.CurrentPosition));
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
                if (input.Equals('+') && char.IsDigit(GetEndCharacter(Context.Accumulator)))
                {
                    Context.Accumulator += input;
                    return this;
                }
                else if (char.IsDigit(input) && GetEndCharacter(Context.Accumulator).Equals('+'))
                {
                    Context.Accumulator += input;
                    return this;
                }
                else if (char.IsDigit(GetEndCharacter(Context.Accumulator)) && char.IsDigit(input))
                {
                    if (!IsEmptyString(Context.Accumulator))
                    {
                        GenerateToken();
                    }
                    return new SingleButtonState(Context).HandleInput(input);
                }
            }
            if (char.IsLetter(input))
            {
                if (!IsEmptyString(Context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(Context).HandleInput(input);
            }
            return new ErrorState(Context);
        }
    }

}
