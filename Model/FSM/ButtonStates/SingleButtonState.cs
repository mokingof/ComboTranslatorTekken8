using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text;

namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
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
            if (!IsReadyForNextInput)
            {
                Context.Accumulator += input.ToString();
                IsReadyForNextInput = true;
                return this;
            }
            if (input.Equals('\0'))
            {
                if (!IsEmptyString(Context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(Context);
            }
            else if (IsReadyForNextInput && char.IsDigit(input))
            {
                if (!IsEmptyString(Context.Accumulator))
                {
                    GenerateToken();
                }
                return new SingleButtonState(Context).HandleInput(input);
            }
            if (input.Equals('+'))
            {

                return new CombinedButtonState(Context).HandleInput(input);
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

