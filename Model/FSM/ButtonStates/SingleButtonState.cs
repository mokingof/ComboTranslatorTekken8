using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text;

namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
{
    public class SingleButtonState : BaseState
    {
       
        public SingleButtonState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.SingleButtons, context.Accumulator, context.CurrentPosition));
            isReadyForNextInput = false;
            context.Accumulator = "";
        }
        public override IState HandleInput(char input)
        {
            if (!isReadyForNextInput)
            {
                context.Accumulator = input.ToString();
                isReadyForNextInput = true;
                return this;
            }
            if (input.Equals('\0'))
            {
                if (!IsEmptyString(context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(context);
            }
            else if (isReadyForNextInput && char.IsDigit(input))
            {
                if (!IsEmptyString(context.Accumulator))
                {
                    GenerateToken();
                }
                return new SingleButtonState(context).HandleInput(input);
            }
            if (input.Equals('+'))
            {

                return new CombinedButtonState(context).HandleInput(input);
            }

            if (char.IsLetter(input))
            {
                if (!IsEmptyString(context.Accumulator))
                {
                    GenerateToken();
                }
                return new ProcessingState(context).HandleInput(input);
            }


            return new ErrorState(context);
        }
    }
}

