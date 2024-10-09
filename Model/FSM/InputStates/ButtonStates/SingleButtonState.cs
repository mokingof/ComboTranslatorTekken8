using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.ButtonStates
{
    public class SingleButtonState : BaseState
    {
        public SingleButtonState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.SingleButtons, Context.Accumulator, Context.CurrentPosition));
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

            if (IsReadyForNextInput && char.IsDigit(input))
            {
                GenerateToken();
                return new SingleButtonState(Context).HandleInput(input);
            }
            else if (input.Equals('+'))
            {
                return new CombinedButtonState(Context).HandleInput(input);
            }
            if (char.IsLetter(input)|| char.IsPunctuation(input) || char.IsSymbol(input))
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

