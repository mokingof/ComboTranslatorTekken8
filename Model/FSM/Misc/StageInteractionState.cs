using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.CoreStates;

namespace ComboTranslatorTekken8.Model.FSM.MiscStates
{
    public class StageInteractionState : BaseState
    {
        public StageInteractionState(ComboContext context) : base(context){}

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.StageInteractions, Context.Accumulator, Context.CurrentPosition));
            ResetAccumulator();
        }

        public override IState HandleInput(char input)
        {
            GenerateToken();
            return new InitialState(Context).HandleInput(input);
        }
    }
}
