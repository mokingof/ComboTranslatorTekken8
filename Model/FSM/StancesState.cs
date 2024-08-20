
namespace ComboTranslatorTekken8.Model.FSM
{
    public class StancesState : BaseState
    {
        public StancesState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.Stances, Accumulator, context.CurrentPosition));
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }

    }
}
