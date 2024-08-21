namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class HoldCombinedDirectionState : BaseState
    {
        public HoldCombinedDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.HoldCombinedDirection, Accumulator, context.CurrentPosition));
        }

        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
    }
}
