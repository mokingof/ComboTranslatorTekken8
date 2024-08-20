using System.Text;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleButtonState : BaseState
    {
        public SingleButtonState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {

            for (int i = 0; i < Accumulator.Length; i++)
            {
                if (Accumulator[i] == ' ')
                {
                    continue;
                }
                AddToken(new Token(TokenType.SingleButtons, Accumulator[i].ToString(), context.CurrentPosition));
            }
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
    }
}
