namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
{
    public class CombinedButtonState : BaseState
    {
        public CombinedButtonState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedButton, Accumulator, context.CurrentPosition));
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
    }
}
