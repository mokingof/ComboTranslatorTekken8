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
        public List<Token> GetTokens()
        {
            return context.SharedTokens;
        }
        public void GenerateToken()
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
        public IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }

        public void AddToken(Token token)
        {
            context.SharedTokens.Add(token);
            context.CurrentPosition++;
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
            Accumulator = "";
        }

    }
}
