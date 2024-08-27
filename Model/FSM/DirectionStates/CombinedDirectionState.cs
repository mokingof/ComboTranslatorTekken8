using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedDirection, Context.Accumulator, Context.CurrentPosition));
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
                if (Context.Accumulator.Equals("df"))
                {
                    GenerateToken();
                    return new InitialState(Context);
                }
            }

            return new ErrorState(Context);

        }
    }
}
