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
    
        public void GenerateToken()
        {
            if (IsUpper(Accumulator))
            {
                context.SharedTokens.Add(new Token(TokenType.HoldCombinedDirection, Accumulator, context.CurrentPosition));
                context.CurrentPosition++;
            }
            else
            {
                context.SharedTokens.Add(new Token(TokenType.CombinedDirection, Accumulator, context.CurrentPosition));
                context.CurrentPosition++;
            }
        }
        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        public List<Token> GetTokens()
        {
            throw new NotImplementedException();
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
