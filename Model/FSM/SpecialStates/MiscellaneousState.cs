namespace ComboTranslatorTekken8.Model.FSM.MiscStates
{
    public class MiscellaneousState : BaseState
    {
        public MiscellaneousState(ComboContext context) : base(context) { }


        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.Miscellaneous, Accumulator, context.CurrentPosition));
        }

        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }


    }
}
