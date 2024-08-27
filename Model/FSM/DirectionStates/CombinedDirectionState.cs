using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedDirection, context.Accumulator, context.CurrentPosition));
        }
        public override IState HandleInput(char input)
        {
            
            return this;
        }
    }
}
