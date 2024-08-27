using ComboTranslatorTekken8.Model.FSM.ButtonStates;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
        private bool isReadyForNextInput = false;
        public SingleDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            if (char.IsUpper(context.Accumulator.ElementAt(0)))
            {
                AddToken(new Token(TokenType.HoldSingleDirection, context.Accumulator, context.CurrentPosition));
            }
            else
            {
                AddToken(new Token(TokenType.SingleDirection, context.Accumulator, context.CurrentPosition));
            }
            
            isReadyForNextInput = false;
            context.Accumulator = "";
        }
        public override IState HandleInput(char input)
        {
            //df db uf ub
            if (!isReadyForNextInput)
            {
                context.Accumulator = input.ToString();
                isReadyForNextInput = true;
                return this;
            }
            
            if (char.IsDigit(input))
            {
                GenerateToken();
                return new SingleButtonState(context).HandleInput(input);

            }

            return this;
        }

    }
}
