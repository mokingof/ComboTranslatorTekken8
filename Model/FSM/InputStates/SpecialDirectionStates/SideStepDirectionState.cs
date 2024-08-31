using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.SpecialDirectionStates
{
    public class SideStepDirectionState : BaseState
    {
        public SideStepDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.Miscellaneous, Context.Accumulator, Context.CurrentPosition));
            IsReadyForNextInput = false;
            ResetAccumulator();
        }

        public override IState HandleInput(char input)
        {
            GenerateToken();
            return new InitialState(Context).HandleInput(input);
        }
    }
}
