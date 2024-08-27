using ComboTranslatorTekken8.Model.FSM.DirectionStates;

namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
{
    public class CombinedButtonState : BaseState
    {
        public CombinedButtonState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedButton, context.Accumulator, context.CurrentPosition));
            isReadyForNextInput = false;
            ResetAccumulator();
        }
        public override IState HandleInput(char input)
        {
            if (input.Equals('\0'))
            {
                if (!IsEmptyString(context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(context);
            }
            if (!isReadyForNextInput)
            {
                context.Accumulator += input;
                isReadyForNextInput = true;
                return this;
            }
            if (isReadyForNextInput)
            {
                if (input.Equals('+') && char.IsDigit(GetEndCharacter(context.Accumulator)))
                {
                    context.Accumulator += input;
                    return this;
                }
                else if (char.IsDigit(input) && GetEndCharacter(context.Accumulator).Equals('+'))
                {
                    context.Accumulator += input;
                    return this;
                }
                else if (char.IsDigit(GetEndCharacter(context.Accumulator)) && char.IsDigit(input))
                {
                    if (!IsEmptyString(context.Accumulator))
                    {
                        GenerateToken();
                    }
                    return new SingleButtonState(context).HandleInput(input);
                }                
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
