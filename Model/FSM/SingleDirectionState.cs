﻿namespace ComboTranslatorTekken8.Model.FSM
{
    public class SingleDirectionState : IState
    {
        private readonly ComboContext context;
       
        public SingleDirectionState(ComboContext context)
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
            if (char.IsUpper(Accumulator,0))
            {
                context.SharedTokens.Add(new Token(TokenType.HoldSingleDirection, Accumulator, context.CurrentPosition));
                context.CurrentPosition++;
            }
            else
            {
                context.SharedTokens.Add(new Token(TokenType.SingleDirection, Accumulator, context.CurrentPosition));
                context.CurrentPosition++;
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
            Accumulator = "";
        }
    }
}
