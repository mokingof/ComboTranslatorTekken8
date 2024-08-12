using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedDirectionState : IState
    {
        private readonly ComboContext context;
    

        public CombinedDirectionState(ComboContext context)
        {
            this.context = context;
        }
        public string Accumulator { get; set; } = "";
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken()
        {
            if (IsUpper(Accumulator))
            {
                return new Token(TokenType.HoldCombinedDirection, Accumulator, context.CurrentPosition);
            }
            else
            {
                return new Token(TokenType.CombinedDirection, Accumulator, context.CurrentPosition);
            }
        }

        public IState HandleInput(string input)
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
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
