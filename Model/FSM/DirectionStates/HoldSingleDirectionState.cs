namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class HoldSingleDirectionState : BaseState
    {

        public HoldSingleDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.HoldSingleDirection, Accumulator, context.CurrentPosition));
        }

        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
    }
}
