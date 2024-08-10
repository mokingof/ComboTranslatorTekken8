using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedDirectionState : IState
    {
        private readonly ComboContext context;
        private string accumulator = "";

        public CombinedDirectionState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            if (IsUpper(accumulator))
            {
                return new Token(TokenType.HoldCombinedDirection, accumulator, context.CurrentPosition);
            }
            else
            {
                return new Token(TokenType.CombinedDirection, accumulator, context.CurrentPosition);
            }
        }

        public IState HandleInput(string input)
        {
            accumulator = input;
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
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
