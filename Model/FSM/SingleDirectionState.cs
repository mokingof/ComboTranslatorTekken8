namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleDirectionState : BaseState
    {
        public SingleDirectionState(ComboContext context) : base(context) {}

        public override void GenerateToken()
        {
            if (char.IsUpper(Accumulator,0))
            {
                AddToken(new Token(TokenType.HoldSingleDirection, Accumulator, context.CurrentPosition));
            }
            else
            {
                AddToken(new Token(TokenType.SingleDirection, Accumulator, context.CurrentPosition));
            }
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }

    }
}
