namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
        public SingleDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.SingleDirection, Accumulator, context.CurrentPosition));
        }
        public override IState HandleInput(char input)
        {
           
            return this;
        }

    }
}
