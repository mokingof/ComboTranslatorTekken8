﻿namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class SpecialDirectionState : BaseState
    {
        public SpecialDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
           
        }
        public override IState HandleInput(char input)
        {
            if (Context.Accumulator.Equals("qcf"))
            {
                AddToken(new Token(TokenType.SingleDirection, "d", Context.CurrentPosition));
                AddToken(new Token(TokenType.CombinedDirection, "df", Context.CurrentPosition));
                AddToken(new Token(TokenType.SingleDirection, "f", Context.CurrentPosition));

            }
            else if (Context.Accumulator.Equals("qcb"))
            {
                AddToken(new Token(TokenType.SingleDirection, "d", Context.CurrentPosition));
                AddToken(new Token(TokenType.CombinedDirection, "db", Context.CurrentPosition));
                AddToken(new Token(TokenType.SingleDirection, "b", Context.CurrentPosition));
            }

            Context.Accumulator = "";
            return new InitialState(Context).HandleInput(input);
        }
    }
}
