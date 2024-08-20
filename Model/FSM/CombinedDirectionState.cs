using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }
 
        public override void GenerateToken()
        {
            if (IsUpper(Accumulator))
            {
                AddToken(new Token(TokenType.HoldCombinedDirection, Accumulator, context.CurrentPosition));   
            }
            else
            {
                AddToken(new Token(TokenType.CombinedDirection, Accumulator, context.CurrentPosition));
            }
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }

        private bool IsUpper(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsUpper(c))
                    return false;
            }
            return true;
        }

    }
}
